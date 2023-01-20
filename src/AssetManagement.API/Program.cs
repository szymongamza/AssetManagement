

using AssetManagement.API;
using AssetManagement.Core.Interfaces;
using AssetManagement.Core.Models;
using AssetManagement.Infrastructure.Data.Repositories;
using AssetManagement.Infrastructure.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

AssetManagement.Infrastructure.Dependencies.ConfigureServices(builder.Configuration, builder.Services);

builder.Services.AddScoped<IBuildingRepo, BuildingRepo>();
builder.Services.AddScoped<IRoomRepo, RoomRepo>();
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<IMaintenanceRepo, MaintenanceRepo>();


builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Open",
        builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
          {
            {
              new OpenApiSecurityScheme
              {
                Reference = new OpenApiReference
                  {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                  },
                  Scheme = "oauth2",
                  Name = "Bearer",
                  In = ParameterLocation.Header,

                },
                new List<string>()
              }
            });

    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "AssetManagement API",
    });

});

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection(nameof(MailSettings)));
builder.Services.AddTransient<IMailService, MailService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseCors("Open");

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "AssetManagement API");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
