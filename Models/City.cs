using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CityAPI.Models {
    public class City {

        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength (50)]
        public string CityName { get; set; }

        [Required]
        [StringLength (100)]
        public string CityPopulation { get; set; }

        [Required]
        [StringLength (10)]
        public string CityArea { get; set; }

        public List<People> people { get; set; }
    }
}