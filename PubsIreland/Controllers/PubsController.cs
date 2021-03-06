﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PubsIreland.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
     public class PubsController : ControllerBase
    {
        private readonly IPubServices _services;
   

        public PubsController(IPubServices services)
        {
            _services = services;

        }

       
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetPubs()
        {
            var pubs = await _services.GetAllPubs();

            return Ok(pubs);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetPubById(int id)
        {
            var pub = await _services.GetPubById(id);
            return Ok(pub); 
        }

        [HttpGet("top/{total}")]
        public async Task<IActionResult> GetPubsNumber(int total)
        {
            var pubs = await _services.GetPubsNumber(total);
            return Ok(pubs);
        }

        [HttpGet("search/cities/{city}")]
        public async Task<IActionResult> GetPubsByCity(string city)
        {
            var pubs = await _services.GetPubsByCity(city);
            return Ok(pubs);
        }

        [HttpGet("oldest/{total}")]
        public async Task<IActionResult> GetOldestPubs(int total)
        {
            var pubs = await _services.GetOldestPubs(total);
            return Ok(pubs);
        }

        [HttpGet("youngest/{total}")]
        public async Task<IActionResult> GetYoungestPubs(int total)
        {
            var pubs = await _services.GetYoungestPubs(total);
            return Ok(pubs);
        }


        [HttpGet("recent/{total}")]
        public async Task<IActionResult> GetRecentAdded(int total)
        {
            var pubs = await _services.GetRecentAdded(total);
            return Ok(pubs);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterPub(PubDtoForCreation dto)
        {
            await _services.RegisterPubAsync(dto);
            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            var pubToken = await _services.Login(dto.Username, dto.Password);

            return Ok(new { token = pubToken});
        }

        [HttpPut("update")]
        [Authorize]
        public async Task<IActionResult> UpdatePub(PubDtoUpdate pub)
        {
            var pubUpdated = await _services.UpdatePub(pub);
            return Ok(pubUpdated);
        }

    }
}