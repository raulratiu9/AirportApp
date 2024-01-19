using Microsoft.EntityFrameworkCore;

namespace AirportAPI.Models
{
    public class AirportContext : DbContext
    {
        public AirportContext(DbContextOptions<AirportContext> options)
        : base(options)
        {
        }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Gate> Gates { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<Company> Companies { get; set; }
    }

}

