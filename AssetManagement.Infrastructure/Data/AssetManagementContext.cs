using AssetManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Infrastructure.Data;

public class AssetManagementContext : DbContext
{
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Building> Buildings { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Asset> Assets { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<Maintenance> Maintenances { get; set; }

    public AssetManagementContext(DbContextOptions<AssetManagementContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}