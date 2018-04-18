using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CityAPI.Models {
    public class People {
        
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string peopleName { get; set; }
        [Required]
        [StringLength(3)]
        public string peopleAge { get; set; }
        [Required]
        [StringLength(5)]
        public string peopleHigh { get; set; }
    }
}