using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ramengo.Dto;
using ramengo.Helper;
using ramengo.Interfaces;
using ramengo.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Globalization;

namespace ramengo.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BrothController : Controller
    {

        private readonly IBrothRepository _brothRepository;
        private readonly IMapper _mapper;

        public BrothController(IBrothRepository brothRepository, IMapper mapper)
        {
            _brothRepository = brothRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all broths", Description = "A list of all available broths")]
        [SwaggerResponse(200, "A list of broths")]
        [SwaggerResponse(403, "Forbidden")]
        public async Task<ActionResult<IEnumerable<BrothDto>>> GetBroths([FromHeader(Name = "x-api-key")] string apiKey, IBrothRepository _brothRepository)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                return StatusCode(403, new { error = "x-api-key header missing" });
            }

            var broths = _brothRepository.GetBroths();
            var brothDtos = _mapper.Map<IEnumerable<BrothDto>>(broths);
            return Ok(brothDtos);
        }

    }
}
