using Localisation.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Localisation.API.Data
{
    public class AppDbContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
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
