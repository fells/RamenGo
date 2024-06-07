using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ramengo.Dto;
using ramengo.Helper;
using ramengo.Interfaces;
using ramengo.Models;
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
            var mappingProfiles = new MappingProfiles();
        }

        [HttpGet]
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
