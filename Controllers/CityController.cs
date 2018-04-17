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
        public async Task<IActionResult> Get (int id) {
            try {

                var cityList = await _context.City.OrderBy (x => x.Id)
                    .Where (x => x.Id == id).ToListAsync ();

                return StatusCode (200, cityList);

            } catch (Exception ex) {
                return StatusCode (500, ex.Message);
            }

        }

        // GET api/values/5
        [HttpGet ("{id}")]
        // public string Get (int id) {
        //     return "value";
        // }

        // POST api/values
        [HttpPost]
        public void Post ([FromBody] string value) { }

        // PUT api/values/5
        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] string value) { }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public void Delete (int id) { }
    }
}