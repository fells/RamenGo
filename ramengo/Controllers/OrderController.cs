using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ramengo.Dto;
using ramengo.Helper;
using ramengo.Interfaces;
using ramengo.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ramengo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly OrderIdService _orderIdService;

        public OrderController(IOrderRepository orderRepository, IMapper mapper, OrderIdService orderIdService)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _orderIdService = orderIdService;
        }

        [HttpPost]
        public async Task<ActionResult<OrderResponseDto>> PlaceOrder([FromBody] OrderRequestDto orderRequestDto)
        {
            if (orderRequestDto.BrothId == 0 || orderRequestDto.ProteinId == 0)
            {
                return BadRequest(new { error = "both brothId and proteinId are required" });
            }

            // Gets the order ID from a external Endpoint
            int orderId;
            try
            {
                orderId = await _orderIdService.GenerateOrderIdAsync();
            }
            catch (HttpRequestException)
            {
                return StatusCode(500, new { error = "could not generate order ID" });
            }

            var order = _mapper.Map<Order>(orderRequestDto);
            order = await _orderRepository.PlaceOrder(order);

            var broth = await _orderRepository.GetBrothById(order.BrothId);
            var protein = await _orderRepository.GetProteinById(order.ProteinId);

            if (broth == null || protein == null)
            {
                return BadRequest(new { error = "Invalid brothId or proteinId" });
            }

            var orderResponseDto = new OrderResponseDto
            {
                Id = orderId,
                Description = $"{broth.Name} and {protein.Name} Ramen",
                Image = "https://tech.redventures.com.br/icons/ramen/ramenChasu.png"
            };

            return CreatedAtAction(nameof(PlaceOrder), new { id = order.Id }, orderResponseDto);
        }
    }
}
