using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityAPI.Models;
using CityAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PeopleAPI.Services.Interfaces;

namespace CityAPI.Services {

    public class PeopleService : IPeople
    {
        public Task<People> deletePeople(int peopleId)
        {
            throw new NotImplementedException();
        }

        public Task<List<People>> getPeople()
        {
            throw new NotImplementedException();
        }

        public Task<List<People>> getPeople(int peopleId)
        {
            throw new NotImplementedException();
        }

        public Task<People> postPeople(People people)
        {
            throw new NotImplementedException();
        }

        public Task<People> updatePeople(int peopleId, People people)
        {
            throw new NotImplementedException();
        }
    }
}