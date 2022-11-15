using Localisation.API.Model;

namespace Localisation.API.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext?>());
            }
        }
        private static void SeedData(AppDbContext context)
        {
            if (!context.Buildings.Any())
            {
                Console.WriteLine("[][][][][] Seeding Data. [][][][][]");
                context.Buildings.AddRange(
                    new Building() { Name = "WIMiIP", BuildingCode = "B5", MinFloor = -1, MaxFloor = 8 },
                    new Building() { Name = "WIMiR", BuildingCode = "B1", MinFloor = -1, MaxFloor = 4 },
                    new Building() { Name = "WIMiIP", BuildingCode = "B4", MinFloor = -1, MaxFloor = 4 }
                    );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("[][][][][] We already have buildings. [][][][][]");

            }
        }
    }
}
