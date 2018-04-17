using System.Collections.Generic;

namespace CityAPI.Models {
    public class Country {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string CountryPopulation { get; set; }
        public string CountryArea { get; set; }
        public List<City> City { get; set; }
    }
}