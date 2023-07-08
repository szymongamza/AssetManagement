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
                new Faculty{ Code="130-000", Name="Wydział Inżynierii Mechanicznej i Robotyki" },
                new Faculty{ Code="230-000", Name="Wydział Informatyki, Elektroniki i Telekomunikacji"}
            };
            context.AddRange(faculties);
            context.SaveChanges();
        }
    }

    public static void SeedDepartments(AssetManagementContext context)
    {
        if (!context.Departments.Any())
        {
            var departments = new List<Department>
            {
                new Department{ Code="230-301", Name="Instytut Elektroniki", FacultyId = 3},
                new Department{ Code="230-302", Name="Instytut Informatyki", FacultyId = 3 },
                new Department{ Code="230-303", Name="Instytut Telekomunikacji", FacultyId = 3},

                new Department{ Code="110-301", Name="Katedra Informatyki Stosowanej i Modelowania", FacultyId = 1},
                new Department{ Code="110-302", Name="Katedra Inżynierii Powierzchni i Analiz Materiałów", FacultyId = 1},
                new Department{ Code="110-303", Name="Katedra Metaloznawstwa i Metalurgii Proszków", FacultyId = 1},
                new Department{ Code="110-304", Name="Katedra Metalurgii Stopów Żelaza", FacultyId = 1},
                new Department{ Code="110-305", Name="Katedra Plastycznej Przeróbki Metali", FacultyId = 1},
                new Department{ Code="110-307", Name="Katedra Plastycznej Przeróbki Metali i Metalurgii Ekstrakcyjnej", FacultyId = 1},
                new Department{ Code="110-306", Name="Katedra Techniki Cieplnej i Ochrony Środowiska", FacultyId = 1},

                new Department{ Code="130-301", Name="Katedra Automatyzacji Procesów", FacultyId = 2},
                new Department{ Code="130-302", Name="Katedra Inżynierii Maszyn i Transportu", FacultyId = 2},
                new Department{ Code="130-303", Name="Katedra Mechaniki i Wibroakustyki", FacultyId = 2},
                new Department{ Code="130-304", Name="Katedra Projektowania i Eksploatacji Maszyn", FacultyId = 2},
                new Department{ Code="130-305", Name="Katedra Robotyki i Mechatroniki", FacultyId = 2},
                new Department{ Code="130-306", Name="Katedra Systemów Energetycznych i Urządzeń Ochrony Środowiska", FacultyId = 2},
                new Department{ Code="130-307", Name="Katedra Systemów Wytwarzania", FacultyId = 2}


            };
            context.AddRange(departments);
            context.SaveChanges();
        }
    }

    public static void SeedBuildings(AssetManagementContext context)
    {
        if (!context.Buildings.Any())
        {
            var buildings = new List<Building>
            {
                new Building{ Code="B-4", City = "Kraków", Street = "al. Mickiewicza 30", PostCode = "30-059"},
                new Building{ Code="B-5", City = "Kraków", Street = "ul. Czarnowiejska 66", PostCode = "30-054"},
                new Building{ Code="D-5", City = "Kraków", Street = "ul. Czarnowiejska 78", PostCode = "30-054"}

            };
            context.AddRange(buildings);
            context.SaveChanges();
        }
    }

    public static void SeedBuildingFaculty(AssetManagementContext context)
    {
        if (!context.BuildingFaculty.Any())
        {
            var buildingFaculties = new List<BuildingFaculty>
            {
                new BuildingFaculty{ BuildingId = 1, FacultyId = 2},
                new BuildingFaculty{ BuildingId = 2, FacultyId = 1},
                new BuildingFaculty{ BuildingId = 3, FacultyId = 3},

            };
            context.AddRange(buildingFaculties);
            context.SaveChanges();
        }
    }

    public static void SeedRooms(AssetManagementContext context)
    {
        if (!context.Rooms.Any())
        {
            var rooms = new List<Room>
            {
                new Room{ Code = "1", BuildingId = 3},
                new Room{ Code = "127", BuildingId = 3},
                new Room{ Code = "128", BuildingId = 3},
                new Room{ Code = "129", BuildingId = 3},
                new Room{ Code = "130", BuildingId = 3},

                new Room{ Code = "101", BuildingId = 1},
                new Room{ Code = "108", BuildingId = 1},
                new Room{ Code = "108A", BuildingId = 1},
                new Room{ Code = "108B", BuildingId = 1},
                new Room{ Code = "118", BuildingId = 1},
                new Room{ Code = "12", BuildingId = 1},
                new Room{ Code = "122", BuildingId = 1},
                new Room{ Code = "123A", BuildingId = 1},
                new Room{ Code = "123B", BuildingId = 1},
                new Room{ Code = "125", BuildingId = 1},
                new Room{ Code = "126A", BuildingId = 1},
                new Room{ Code = "126B", BuildingId = 1},
                new Room{ Code = "126C", BuildingId = 1},
                new Room{ Code = "127A", BuildingId = 1},
                new Room{ Code = "128A", BuildingId = 1},
                new Room{ Code = "128B", BuildingId = 1},
                new Room{ Code = "13", BuildingId = 1},
                new Room{ Code = "132", BuildingId = 1},
                new Room{ Code = "133", BuildingId = 1},
                new Room{ Code = "14C", BuildingId = 1},
                new Room{ Code = "15", BuildingId = 1},
                new Room{ Code = "16", BuildingId = 1},
                new Room{ Code = "203", BuildingId = 1},
                new Room{ Code = "204", BuildingId = 1},
                new Room{ Code = "209", BuildingId = 1},
                new Room{ Code = "302", BuildingId = 1},
                new Room{ Code = "303", BuildingId = 1},
                new Room{ Code = "308a", BuildingId = 1},
                new Room{ Code = "312", BuildingId = 1},
                new Room{ Code = "313", BuildingId = 1},
                new Room{ Code = "314", BuildingId = 1},
                new Room{ Code = "314A", BuildingId = 1},
                new Room{ Code = "H10", BuildingId = 1},
                new Room{ Code = "H6", BuildingId = 1},
                new Room{ Code = "H8", BuildingId = 1},
                new Room{ Code = "HB14", BuildingId = 1},

                new Room{ Code = "101", BuildingId = 2},
                new Room{ Code = "102", BuildingId = 2},
                new Room{ Code = "104", BuildingId = 2},
                new Room{ Code = "107", BuildingId = 2},
                new Room{ Code = "110", BuildingId = 2},
                new Room{ Code = "20", BuildingId = 2},
                new Room{ Code = "201a", BuildingId = 2},
                new Room{ Code = "210", BuildingId = 2},
                new Room{ Code = "212", BuildingId = 2},
                new Room{ Code = "214", BuildingId = 2},
                new Room{ Code = "215", BuildingId = 2},
                new Room{ Code = "304", BuildingId = 2},
                new Room{ Code = "307", BuildingId = 2},
                new Room{ Code = "311", BuildingId = 2},
                new Room{ Code = "402", BuildingId = 2},
                new Room{ Code = "404", BuildingId = 2},
                new Room{ Code = "410", BuildingId = 2},
                new Room{ Code = "510", BuildingId = 2},
                new Room{ Code = "512", BuildingId = 2},
                new Room{ Code = "601", BuildingId = 2},
                new Room{ Code = "608", BuildingId = 2},
                new Room{ Code = "609", BuildingId = 2},
                new Room{ Code = "610", BuildingId = 2},
                new Room{ Code = "612", BuildingId = 2},
                new Room{ Code = "702", BuildingId = 2},
                new Room{ Code = "709", BuildingId = 2},
                new Room{ Code = "810", BuildingId = 2},
                new Room{ Code = "819", BuildingId = 2},




            };
            context.AddRange(rooms);
            context.SaveChanges();
        }
    }

    public static void SeedManufacturers(AssetManagementContext context)
    {
        if (!context.Manufacturers.Any())
        {
            var manufacturers = new List<Manufacturer>
            {
                new Manufacturer{ Name="Fanuc", Email = "fanuc@fanuc.com", PhoneNumber = "111222333"},
                new Manufacturer{ Name="Siemens", Email = "siemens@siemens.com", PhoneNumber = "333222111"},

            };
            context.AddRange(manufacturers);
            context.SaveChanges();
        }
    }

    public static void SeedUsers(AssetManagementContext context)
    {
        if (!context.Users.Any())
        {
            var users = new List<User>
            {
                new User{ Name="Testowy Pracownik", Email = "test@mail.com", PhoneNumber = "111222333"},
                new User{ Name="Pracownik Testowy", Email = "mail@test.com", PhoneNumber = "333222111"},

            };
            context.AddRange(users);
            context.SaveChanges();
        }
    }
}
