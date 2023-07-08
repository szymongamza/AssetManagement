using AssetManagement.Infrastructure;
using AssetManagement.Application;
using Microsoft.OpenApi.Models;
using System;
using AssetManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AssetManagement.Api;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddApplication();

    builder.Services.AddControllers();
    builder.Services.AddSwaggerGen(c =>
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AssetManagement", Version = "v1", Description = "Api made for SPA frontend. Made by Szymon" })
);
}


var app = builder.Build();
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
    app.MapControllers();

    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<AssetManagementContext>();
        db.Database.Migrate();
        DataSeed.SeedFaculties(db);
        DataSeed.SeedDepartments(db);
        DataSeed.SeedBuildings(db);
        DataSeed.SeedBuildingFaculty(db);
        DataSeed.SeedRooms(db);
        DataSeed.SeedManufacturers(db);
        DataSeed.SeedUsers(db);
    }

    app.Run();
}