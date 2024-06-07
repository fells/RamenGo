using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ramengo.Dto;
using ramengo.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ramengo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProteinController : Controller
    {
        private readonly IProteinRepository _proteinRepository;
        private readonly IMapper _mapper;

        public ProteinController(IProteinRepository proteinRepository, IMapper mapper)
        {
            _proteinRepository = proteinRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all proteins", Description = "A list of all available proteins")]
        [SwaggerResponse(200, "A list of proteins")]
        [SwaggerResponse(403, "Forbidden")]
        public async Task<ActionResult<IEnumerable<ProteinDto>>> GetProtein([FromHeader(Name = "x-api-key")] string apiKey, IProteinRepository _proteinRepository)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                return StatusCode(403, new { error = "x-api-key header missing" });
            }

            var proteins = _proteinRepository.GetProtein();
            var proteinDtos = _mapper.Map<IEnumerable<ProteinDto>>(proteins);
            return Ok(proteinDtos);
        }
    }
}
