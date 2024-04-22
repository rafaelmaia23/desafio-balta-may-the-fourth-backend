using MayTheFourthApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourthApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<StarShip> StarShips { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
