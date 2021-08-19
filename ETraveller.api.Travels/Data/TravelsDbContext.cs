using ETraveller.api.Travels.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ETraveller.api.Travels.Data
{
    public class TravelsDbContext : DbContext
    {
        public DbSet<Travel> Travels { get; set; }
        public TravelsDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Travel>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");

                entity.Property(e => e.UserId);
                entity.Property(e => e.Name);
                entity.Property(e => e.Type);
            });
        }
    }
}
