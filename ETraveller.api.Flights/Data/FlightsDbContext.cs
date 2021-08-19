using ETraveller.api.Flights.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ETraveller.api.Flights.Data
{
    public class FlightsDbContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public FlightsDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");

                entity.Property(e => e.FlightClass);
                entity.Property(e => e.Departure);
                entity.Property(e => e.DepartureTime);
                entity.Property(e => e.Arrival);
                entity.Property(e => e.ArrivalTime);

            });
        }
    }
}
