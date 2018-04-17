using Microsoft.EntityFrameworkCore;

namespace CityAPI.Models {
    public class ApplicationDbContext : DbContext {

        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base (options) {

        }

        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
    }
}