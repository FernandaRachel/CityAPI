using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityAPI.Models;
using CityAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CityAPI.Controllers {
    [Route ("api/[controller]")]
    public class CountryController : Controller {

        private readonly ApplicationDbContext _context;
        private readonly CountryService _countryService;

        public CountryController (ApplicationDbContext context, CountryService countryService) {
            _context = context;
            _countryService = countryService;
        }

        // GET api/country
        [HttpGet]
        public async Task<IActionResult> Get () {

            var countryList = await _countryService.getCountry ();

            return Ok (countryList);

        }

        // GET api/country/5
        [HttpGet ("{id}")]
        public async Task<IActionResult> Get (int id) {

            var country = await _countryService.getCountry (id);

            if (country == null) {
                return NotFound ();
            }

            return Ok (country);

        }
        // POST api/country
        [HttpPost]
        public async Task<IActionResult> Post (int id, [FromBody] Country country) {

            if (ModelState.IsValid) {

                await _countryService.postCountry(country);

                return Created ($"api/city/{country.Id}", country);
            }

            return BadRequest (ModelState);
        }

        // PUT api/country/5
        [HttpPut ("{id}")]
        public async Task<IActionResult> Put (int id, [FromBody] Country country) {
             if (ModelState.IsValid) {

                await _countryService.updateCountry (id, country);

                return Created ($"api/city/{country.Id}", country);
            }
            
            return BadRequest (ModelState);

        }

        // DELETE api/country/5
        [HttpDelete ("{id}")]
        public void Delete (int id) { }
    }
}