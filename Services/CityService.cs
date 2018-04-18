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

    public class CityService : ICity {

        private readonly ApplicationDbContext _context;
        private IConfiguration _configuration;

        public CityService (IConfiguration configuration, ApplicationDbContext context) {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<City>> getCity () {

            var citylist = await _context.City
                .Include (c => c.people)
                .ToListAsync ();

            return citylist;
        }

        public async Task<List<City>> getCity (int cityId) {
            var cityobj = await _context.City
                .Include (c => c.people)
                .Where (c => c.Id == cityId)
                .ToListAsync ();

            return cityobj;
        }

        public async Task<City> updateCity (int CityId, City city) {

            var currentcity = await _context.City
                .Where (x => x.Id == CityId)
                .Include (x => x.people)
                .AsNoTracking ()
                .FirstOrDefaultAsync ();

            _context.City.Update (city);
            await _context.SaveChangesAsync ();

            return currentcity;
        }

        public async Task<City> postCity (City city) {

            city.Id = 0;
            city.people = new List<People> ();

            await _context.City.AddAsync (city);
            await _context.SaveChangesAsync ();

            return city;
        }

        public async Task<City> deleteCity (int cityId) {
            
            var city = await _context.City
                .Where (c => c.Id == cityId)
                .FirstOrDefaultAsync ();

            if (city != null) {
                _context.Entry (city).State = EntityState.Deleted;

                await _context.SaveChangesAsync ();
            }

            return city;
        }
    }
}