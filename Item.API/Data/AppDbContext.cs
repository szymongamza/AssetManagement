using Microsoft.EntityFrameworkCore;
using Item.API.Model;

namespace Item.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
