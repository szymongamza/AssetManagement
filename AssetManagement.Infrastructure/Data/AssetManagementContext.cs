﻿using AssetManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Infrastructure.Data;

public class AssetManagementContext : DbContext
{
    private readonly AuditableEntitySaveChangesInterceptor _interceptor;
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Department> Departments { get; set; } 
    public DbSet<Building> Buildings { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Asset> Assets { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<Stocktaking> Stocktakings { get; set; }
    public DbSet<AssetStocktaking> AssetStocktaking { get; set; }
    public DbSet<BuildingFaculty> BuildingFaculty { get; set; }
    public DbSet<User> Users { get; set; }

    public AssetManagementContext(DbContextOptions<AssetManagementContext> options, AuditableEntitySaveChangesInterceptor interceptor) : base(options)
    {
        _interceptor = interceptor;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_interceptor);
        optionsBuilder.EnableSensitiveDataLogging();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Faculty>().HasMany(e => e.Buildings).WithMany(e => e.Faculties)
            .UsingEntity<BuildingFaculty>();
        modelBuilder.Entity<Stocktaking>().HasMany(e => e.Assets).WithMany(e => e.Stocktakings).UsingEntity<AssetStocktaking>();

        base.OnModelCreating(modelBuilder);
        
    }

}