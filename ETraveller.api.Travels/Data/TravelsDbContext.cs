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
    }
}
