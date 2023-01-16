using AssetManagementAPI.Data;
using AssetManagementAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class MaintenanceRepoFake : IMaintenanceRepo
    {
        private readonly List<Maintenance> _maintenances;

        public MaintenanceRepoFake()
        {
            _maintenances = new List<Maintenance>()
            {
                new Maintenance() {
                    Id = 1, 
                    Description = "Changed belts", 
                    DateStart = DateTime.Parse("2022-04-26"),
                    DateEnd = DateTime.Parse("2022-04-28"),
                    ProductId = 1
                },
                new Maintenance() {
                    Id = 2,
                    Description = "Changed screws",
                    DateStart = DateTime.Parse("2022-05-26"),
                    DateEnd = DateTime.Parse("2022-05-28"),
                    ProductId = 1
                },
                new Maintenance() {
                    Id = 3,
                    Description = "Changed screws",
                    DateStart = DateTime.Parse("2022-04-26"),
                    DateEnd = DateTime.Parse("2022-04-28"),
                    ProductId = 2
                }
            };
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task CreateMaintenance(Maintenance maintenance)
        {
            _maintenances.Add(maintenance);
        }

        public async Task<Maintenance?> GetLastMaintenanceOfProduct(int productId)
        {
            return _maintenances.OrderByDescending(x => x.DateEnd).First();
        }

        public async Task<Maintenance?> GetMaintenanceById(int id)
        {
            return _maintenances.Find(x => x.Id == id);
        }

        public async Task<IEnumerable<Maintenance>> GetMaintenancesOfProduct(int productId)
        {
            return _maintenances.FindAll(x => x.ProductId == productId);
        }
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    }
}
