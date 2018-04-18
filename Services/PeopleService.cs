using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityAPI.Models;
using CityAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CityAPI.Services {

    public class PeopleService : IPeople {

        private readonly ApplicationDbContext _context;
        private IConfiguration _configuration;

        public PeopleService (IConfiguration configuration, ApplicationDbContext context) {
            _context = context;
            _configuration = configuration;
        }
        public async Task<List<People>> getPeople () {
            var peoplelist = await _context.People
                .ToListAsync ();

            return peoplelist;
        }

        public async Task<List<People>> getPeople (int peopleId) {
            var peoplelist = await _context.People
                .Where (c => c.Id == peopleId)
                .ToListAsync ();

            return peoplelist;
        }

        public async Task<People> postPeople (People people) {

            people.Id = 0;

            await _context.People.AddAsync (people);
            await _context.SaveChangesAsync ();

            return people;
        }

        public async Task<People> deletePeople (int peopleId) {
            var peopleobj = await _context.People
                .Where (c => c.Id == peopleId)
                .FirstOrDefaultAsync ();

            if (peopleobj != null) {
                _context.Entry (peopleobj).State = EntityState.Deleted;

                await _context.SaveChangesAsync ();
            }
            return peopleobj;
        }

        public async Task<People> updatePeople (int peopleId, People people) {
            var currentpeople = await _context.People
                .Where (x => x.Id == peopleId)
                .AsNoTracking ()
                .FirstOrDefaultAsync ();

            _context.People.Update (people);
            await _context.SaveChangesAsync ();

            return people;
        }
    }
}