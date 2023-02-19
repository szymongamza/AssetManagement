using AssetManagement.Api.Helpers;
using AssetManagement.Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);
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

    app.Run();
}