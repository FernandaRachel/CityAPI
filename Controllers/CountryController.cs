using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CityAPI.Controllers {
    [Route ("api/[controller]")]
    public class CountryController : Controller {

        private readonly ApplicationDbContext _context;

        public CountryController (ApplicationDbContext context) {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get () {

            var countryList = await _context.Country.Include (c => c.City).ToListAsync ();

            return Ok (countryList);

        }

        // GET api/values/5
        [HttpGet ("{id}")]
        public async Task<IActionResult> Get (int id) {

            var countryList = await _context.Country.Include (c => c.City)
                .Where (c => c.Id == id)
                .ToListAsync ();
            if (countryList == null) {
                return NotFound ();
            }
            return Ok (countryList);

        }
        // POST api/city
        [HttpPost]
        public async Task<IActionResult> Post ([FromBody] Country country) {
            try {

                country.Id = 0;

                if (ModelState.IsValid) {

                    await _context.Country.AddAsync (country);
                    await _context.SaveChangesAsync ();

                    return Created ($"api/city/{country.Id}", country);
                } else {
                    return BadRequest (ModelState);
                }

            } catch (Exception ex) {
                return StatusCode (500, ex.Message);
            }
        }

        // PUT api/values/5
        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] string value) { }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public void Delete (int id) { }
    }
}