using Item.API.Model;

namespace Item.API.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }
        private static void SeedData(AppDbContext context)
        {
            if (!context.Products.Any())
            {
                Console.WriteLine("[][][][][] Seeding Data. [][][][][]");
                context.Products.AddRange(
                    new Product() { 
                        Name = "Signal Pro 300",
                        Manufacturer = "ATMAT",
                        ManufacturerSerialNumber = "123-453-654",
                        AdditionalDescription = "Drukarka 3D, dysze: 04 i 04",
                        DateTimeOfBuy = DateTime.Parse("2022-10-26"),
                        DateTimeOfEndOfGuarantee = DateTime.Parse("2023-10-26"),
                        DateTimeOfNextMaintainance = DateTime.Parse("2023-04-26"),
                        RoomId = 1 }
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
