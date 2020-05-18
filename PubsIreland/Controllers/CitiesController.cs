using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace PubsIreland.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        private readonly ICityServices _service;
        public CitiesController(ICityServices service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cities = await _service.GetCities();
            return Ok(cities);
        }

        [HttpGet("{city}")]
        public async Task<IActionResult> GetCities(string city)
        {
            var cities = await _service.GetCities(city);
            return Ok(cities);
        }
    }
}