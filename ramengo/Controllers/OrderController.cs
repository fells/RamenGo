using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ramengo.Dto;
using ramengo.Interfaces;
using ramengo.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ramengo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<OrderResponseDto>> PlaceOrder([FromBody] OrderRequestDto orderRequestDto)
        {
            if (orderRequestDto.BrothId == 0 || orderRequestDto.ProteinId == 0)
            {
                return BadRequest(new { error = "both brothId and proteinId are required" });
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
                Id = order.Id,
                Description = $"{broth.Name} and {protein.Name} Ramen",
                Image = "https://tech.redventures.com.br/icons/ramen/ramenChasu.png"
            };

            return CreatedAtAction(nameof(PlaceOrder), new { id = order.Id }, orderResponseDto);
        }
    }
}
