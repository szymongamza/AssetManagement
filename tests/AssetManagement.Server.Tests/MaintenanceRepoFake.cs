using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Server.Data.MaintenanceRepo;
using AssetManagement.Server.Model;

namespace AssetManagement.Server.Tests
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

        public Task CreateMaintenance(Maintenance maintenance)
        {
            _maintenances.Add(maintenance);
            return Task.CompletedTask;
        }

        public Task<Maintenance?> GetLastMaintenanceOfProduct(int productId)
        {
            return Task.FromResult(_maintenances.OrderByDescending(x => x.DateEnd).First());
        }

        public Task<Maintenance?> GetMaintenanceById(int id)
        {
            return Task.FromResult(_maintenances.Find(x => x.Id == id));
        }

        public Task<IEnumerable<Maintenance>> GetMaintenancesOfProduct(int productId)
        {
            return Task.FromResult<IEnumerable<Maintenance>>(_maintenances.FindAll(x => x.ProductId == productId));
        }
    }
}
