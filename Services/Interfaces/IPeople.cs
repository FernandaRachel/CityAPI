using System.Collections.Generic;
using System.Threading.Tasks;
using CityAPI.Models;

namespace PeopleAPI.Services.Interfaces
{
    public interface IPeople
    {
        // Task<(List<Country>, int)> getRecipes(int startat, int quantity,List<string> fields,
        //      CountryFields orderField);
        Task<List<People>> getPeople();
        Task<List<People>> getPeople(int peopleId);
        Task<People> updatePeople(int peopleId, People people);
        Task<People> postPeople(People people);
        Task<People> deletePeople(int peopleId);
    }
    public enum PeopleFields
    {
        Default,
        cityName,
    }
}