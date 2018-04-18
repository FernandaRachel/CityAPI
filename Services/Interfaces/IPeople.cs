using System.Collections.Generic;
using System.Threading.Tasks;
using CityAPI.Models;

namespace CityAPI.Services.Interfaces {
    public interface IPeople {
        // Task<(List<Country>, int)> getRecipes(int startat, int quantity,List<string> fields,
        //      CountryFields orderField);
        Task<List<People>> getPeople ();
        Task<List<People>> getPeople (int peopleId);
        Task<People> postPeople (People people);
        Task<People> updatePeople (int peopleId, People people);
        Task<People> deletePeople (int peopleId);
    }
    public enum PeopleFields {
        Default,
        peopleName,
    }
}