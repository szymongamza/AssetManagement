using AssetManagement.Domain.Entities;
using AssetManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace AssetManagement.Api;

public class DataSeed
{
    public static void SeedFaculties(AssetManagementContext context)
    {
        if (!context.Faculties.Any())
        {
            var faculties = new List<Faculty>
            {
                new Faculty{ Code="110-000", Name="Wydział Inżynierii Metali i Informatyki Przemysłowej"},
                new Faculty{ Code="130-000", Name="Wydział Inżynierii Mechanicznej i Robotyki}" },
                new Faculty{ Code="230-000", Name="Wydział Informatyki, Elektroniki i Telekomunikacji"}
            };
            context.AddRange(faculties);
            context.SaveChanges();
        }
    }
}
