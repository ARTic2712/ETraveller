using ETraveller.api.Accommodations.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ETraveller.api.Accommodations.Data
{
    public class AccommodationsDbContext : DbContext
    {
        public DbSet<Accommodation> Accommodations { get; set; }
        public AccommodationsDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accommodation>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");

                entity.Property(e => e.Name);
                entity.Property(e => e.Adress);
                entity.Property(e => e.CheckOut);
                entity.Property(e => e.CheckIn);
                entity.Property(e => e.Comments);
            });
        }
    }
}
