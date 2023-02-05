using AssetManagement.Api.Common.Mapping;
using AssetManagement.Application;
using AssetManagement.Infrastructure;


var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    builder.Services.AddAutoMapper(typeof(AuthenticationMappingProfile).Assembly);
    builder.Services.AddControllers();
}


var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}