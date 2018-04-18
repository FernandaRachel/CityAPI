using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CityAPI.Controllers {
    [Route ("api/[controller]")]
    public class CityController : Controller {

        private readonly ApplicationDbContext _context;

        public CityController (ApplicationDbContext context) {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get () {

            var cityList = await _context.City.Include (c => c.people).ToListAsync ();

            if (cityList == null) {
                return NotFound (cityList);
            }
            return Ok (cityList);

        }

        // GET api/city/5
        [HttpGet ("{id}")]
        public async Task<IActionResult> Get (int id) {

            var cityList = await _context.City.Include (c => c.people)
                .Where (c => c.Id == id)
                .ToListAsync ();

            if (cityList == null) {
                return NotFound (cityList);
            }

            return Ok (cityList);

        }

        // POST api/city
        [HttpPost]
        public async Task<IActionResult> Post ([FromBody] City city) {
            try {

                city.Id = 0;

                if (ModelState.IsValid) {

                    await _context.City.AddAsync (city);
                    await _context.SaveChangesAsync ();

                    return Created ($"api/city/{city.Id}", city);
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
        public void Delete (int id) { 
            
        }
    }
}