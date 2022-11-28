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
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Building>()
                .HasMany(p => p.Rooms)
                .WithOne(p => p.Building!)
                .HasForeignKey(p => p.BuildingId);

            modelBuilder
                .Entity<Room>()
                .HasOne(p => p.Building)
                .WithMany(p => p.Rooms);

            modelBuilder
                .Entity<Room>()
                .HasMany(p => p.Products)
                .WithOne(p => p.Room!)
                .HasForeignKey(p => p.RoomId);

            modelBuilder
                .Entity<Product>()
                .HasOne(p => p.Room)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.RoomId);
        }
    }

}
