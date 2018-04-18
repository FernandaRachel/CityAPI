using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityAPI.Models;
using CityAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CityAPI.Controllers {
    [Route ("api/[controller]")]
    public class CityController : Controller {

        private readonly ApplicationDbContext _context;
        private readonly ICity _cityService;

        public CityController (ApplicationDbContext context, ICity cityService) {
            _context = context;
            _cityService = cityService;
        }

        // GET api/city
        [HttpGet]
        public async Task<IActionResult> Get () {

            var cityList = await _cityService.getCity ();

            if (cityList == null) {
                return NotFound (cityList);
            }
            return Ok (cityList);

        }

        // GET api/city/5
        [HttpGet ("{id}")]
        public async Task<IActionResult> Get (int id) {

            var cityList = await _cityService.getCity ();

            if (cityList == null) {
                return NotFound (cityList);
            }

            return Ok (cityList);

        }

        // POST api/city
        [HttpPost]
        public async Task<IActionResult> Post ([FromBody] City city) {
            if (ModelState.IsValid) {

                await _cityService.postCity (city);

                return Created ($"api/city/{city.Id}", city);
            }

            return BadRequest (ModelState);

        }

        // PUT api/city/5
        [HttpPut ("{id}")]
        public async Task<IActionResult> Put (int id, [FromBody] City city) {
            
            await _cityService.updateCity (id, city);

            return Ok (city);
        }

        // DELETE api/city/5
        [HttpDelete ("{id}")]
        public async Task<IActionResult> Delete (int id) {
            
            await _cityService.deleteCity (id);

            return Ok (id);

        }
    }
}