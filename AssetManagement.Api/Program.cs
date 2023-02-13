using AssetManagement.Api.Common.Mapping;
using AssetManagement.Application;
using AssetManagement.Infrastructure;
using Microsoft.OpenApi.Models;
using System;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    builder.Services.AddAutoMapper(typeof(AuthenticationMappingProfile).Assembly);
    builder.Services.AddControllers();
    builder.Services.AddSwaggerGen(c =>
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AssetManagement", Version = "v1", Description = "Api made for SPA frontend. Made by Szymon" })
);
}


var app = builder.Build();
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();

    app.Run();
}