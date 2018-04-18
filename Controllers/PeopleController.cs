using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityAPI.Models;
using CityAPI.Services;
using CityAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CityAPI.Controllers {
    [Route ("api/[controller]")]
    public class PeopleController : Controller {

        private readonly ApplicationDbContext _context;
        private readonly IPeople _peopleService;

        public PeopleController (ApplicationDbContext context, IPeople peopleService) {
            _context = context;
            _peopleService = peopleService;
        }

        // GET api/people
        [HttpGet]
        public async Task<IActionResult> Get () {

            var countryList = await _peopleService.getPeople ();

            return Ok (countryList);

        }

        // GET api/People/5
        [HttpGet ("{id}")]
        public async Task<IActionResult> Get (int id) {

            var people = await _peopleService.getPeople (id);

            if (people == null) {
                return NotFound ();
            }

            return Ok (people);

        }
        // POST api/people
        [HttpPost]
        public async Task<IActionResult> Post ([FromBody] People people) {

            if (ModelState.IsValid) {

                await _peopleService.postPeople (people);

                return Created ($"api/people/{people.Id}", people);
            }

            return BadRequest (ModelState);
        }

        // PUT api/people/5
        [HttpPut ("{id}")]
        public async Task<IActionResult> Put (int id, [FromBody] People people) {
            if (ModelState.IsValid) {

                await _peopleService.updatePeople (id, people);

                return Ok (people);
            }

            return BadRequest (ModelState);

        }

        // DELETE api/people/5
        [HttpDelete ("{id}")]
        public async Task<IActionResult> Delete (int id) {

            await _peopleService.deletePeople (id);

            return Ok (id);
        }
    }
}