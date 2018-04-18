using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityAPI.Models;
using CityAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CityAPI.Services {

    public class CountryService : ICountry {

        private readonly ApplicationDbContext _context;

        public CountryService (ApplicationDbContext context) {
            _context = context;
        }
        public async Task<List<Country>> getCountry () {

            var countryList = await _context.Country
                .Include (c => c.City)
                .ThenInclude (c => c.people)
                .ToListAsync ();

            return countryList;
        }

        public async Task<List<Country>> getCountry (int id) {

            var countryObj = await _context.Country.Include (c => c.City)
                .ThenInclude (c => c.people)
                .Where (c => c.Id == id)
                .ToListAsync ();

            return countryObj;
        }

        public async Task<Country> postCountry (Country country) {

            await _context.Country.AddAsync (country);
            await _context.SaveChangesAsync ();

            return country;
        }

        public async Task<Country> updateCountry (int countryId, Country country) {
            country.Id = 0;

            await _context.Country.AddAsync (country);
            await _context.SaveChangesAsync ();

            return country;

        }

        public async Task<Country> deleteCountry (int countryId) {
           var country = await  _context.Country
            .Where( c => c.Id == countryId)
            .FirstOrDefaultAsync();

            if (country != null)
            {
                _context.Entry(country).State = EntityState.Deleted;
                
                await _context.SaveChangesAsync();
            }


            return country;
        }
    }
}