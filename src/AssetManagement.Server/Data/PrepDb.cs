using AssetManagement.Server.Model;

namespace AssetManagement.Server.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
#pragma warning disable CS8604 // Possible null reference argument.
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext?>());
#pragma warning restore CS8604 // Possible null reference argument.
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

            if (!context.Rooms.Any())
            {
                Console.WriteLine("[][][][][] Seeding Data. [][][][][]");
                context.Rooms.AddRange(
                    new Room() {Name = "120", BuildingId = 1, Floor = 1},
                    new Room() {Name = "320", BuildingId = 2, Floor = 3}
                    );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("[][][][][] We already have rooms. [][][][][]");

            }

            if (!context.Products.Any())
            {
                Console.WriteLine("[][][][][] Seeding Data. [][][][][]");
                context.Products.AddRange(
                    new Product()
                    {
                        Name = "Signal Pro 300",
                        Manufacturer = "ATMAT",
                        ManufacturerSerialNumber = "123-453-654",
                        AdditionalDescription = "Drukarka 3D, dysze: 04 i 04",
                        DateTimeOfBuy = DateTime.Parse("2022-10-26"),
                        DateTimeOfEndOfGuarantee = DateTime.Parse("2023-10-26"),
                        DateTimeOfNextMaintainance = DateTime.Parse("2023-04-26"),
                        EmailNotification = true,
                        RoomId = 1
                    },
                    new Product()
                    {
                        Name = "Signal Pro 400",
                        Manufacturer = "ATMAT",
                        ManufacturerSerialNumber = "123-453-655",
                        AdditionalDescription = "Drukarka 3D, dysze: 04 i 04",
                        DateTimeOfBuy = DateTime.Parse("2021-10-26"),
                        DateTimeOfEndOfGuarantee = DateTime.Parse("2022-10-26"),
                        DateTimeOfNextMaintainance = DateTime.Parse("2023-04-26"),
                        EmailNotification = true,
                        RoomId = 1
                    }
                    );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("[][][][][] We already have products. [][][][][]");

            }
            if (!context.Maintenances.Any())
            {
                Console.WriteLine("[][][][][] Seeding Data. [][][][][]");
                context.Maintenances.AddRange(
                    new Maintenance()
                    {
                        DateStart = DateTime.Parse("2022-04-26"),
                        DateEnd = DateTime.Parse("2022-04-30"),
                        Description = "Wymiana pasków napędowych",
                        ProductId = 2
                    },
                    new Maintenance()
                    {
                        DateStart = DateTime.Parse("2022-10-26"),
                        DateEnd = DateTime.Parse("2022-11-05"),
                        Description = "Przesmarowanie mechaniki",
                        ProductId = 2
                    }
                    );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("[][][][][] We already have maintenances. [][][][][]");

            }
        }
    }
}
