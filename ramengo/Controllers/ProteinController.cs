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
        public async Task<ActionResult<IEnumerable<ProteinDto>>> GetProteins([FromHeader(Name = "x-api-key")] string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                return Forbid("x-api-key header missing");
            }

            var proteins = await _proteinRepository.GetAllProteins();
            var proteinsDto = _mapper.Map<IEnumerable<ProteinDto>>(proteins);
            return Ok(proteinsDto);
        }
    }
}
