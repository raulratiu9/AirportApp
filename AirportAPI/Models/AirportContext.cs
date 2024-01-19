using AirportAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AirportAPI.Data
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().ToTable("Flight");
            modelBuilder.Entity<Gate>().ToTable("Gate");
            modelBuilder.Entity<Passenger>().ToTable("Passenger");
            modelBuilder.Entity<Aircraft>().ToTable("Aircraft");
            modelBuilder.Entity<Company>().ToTable("Company");
        }
    }

}

