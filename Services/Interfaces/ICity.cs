using System.Collections.Generic;
using System.Threading.Tasks;
using CityAPI.Models;

namespace CityAPI.Services.Interfaces {
    public interface ICity {
        // Task<(List<Country>, int)> getRecipes(int startat, int quantity,List<string> fields,
        //      CountryFields orderField);
        Task<List<City>> getCity ();
        Task<List<City>> getCity (int cityId);
        Task<City> postCity (City city);
        Task<City> updateCity (int CityId, City city);
        Task<City> deleteCity (int CityId);
    }
    public enum CityFields {
        Default,
        cityName,
    }
}