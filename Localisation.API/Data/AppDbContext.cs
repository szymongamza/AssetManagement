using Localisation.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Localisation.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
