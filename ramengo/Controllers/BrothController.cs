﻿using AutoMapper;
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
        public async Task<IActionResult> GetAllBroths([FromHeader(Name = "x-api-key")] string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                return Forbid("x-api-key header missing"); // Retorna 403 Forbidden sem um corpo de mensagem
            }

            var broths = await _brothRepository.GetAllBroths();
            var brothsDto = _mapper.Map<IEnumerable<BrothDto>>(broths);
            return Ok(brothsDto);
        }

    }
}




