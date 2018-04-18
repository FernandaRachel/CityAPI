using System.Collections.Generic;
using System.Threading.Tasks;
using CityAPI.Models;

namespace CityAPI.Services.Interfaces
{
    public interface ICountry
    {
        // Task<(List<Country>, int)> getRecipes(int startat, int quantity,List<string> fields,
        //      CountryFields orderField);
        Task<List<Country>> getCountry();
        Task<List<Country>> getCountry(int countryId);
        Task<Country> updateCountry(int countryId, Country country);
        Task<Country> postCountry(Country country);
        Task<Country> deleteCountry(int countryId);
    }
    public enum CountryFields
    {
        Default,
        countryName,
    }
}