using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssetManagement.Server.Data.ProductRepo;
using AssetManagement.Server.Model;

namespace AssetManagement.Server.Tests
{
    public class ProductRepoFake:IProductRepo
    {
        private readonly List<Product> _products;

        public ProductRepoFake()
        {
            _products = new List<Product>()
            {
                new Product() {
                    Id = 1,
                    Name = "Signal Pro 300",
                    Manufacturer = "ATMAT",
                    AdditionalDescription = "3D Printer",
                    DateTimeOfBuy = new DateTime(2022,6,12),
                    DateTimeOfEndOfGuarantee = new DateTime(2023,6,12),
                    DateTimeOfNextMaintainance= new DateTime(2022,12,12),
                    ManufacturerSerialNumber = "2022/321534/34234",
                    EmailNotification = true,
                    RoomId = 1
                },       
                new Product() {
                    Id = 2,
                    Name = "Signal Pro 400",
                    Manufacturer = "ATMAT",
                    AdditionalDescription = "3D Printer",
                    DateTimeOfBuy = new DateTime(2022,6,12),
                    DateTimeOfEndOfGuarantee = new DateTime(2023,6,12),
                    DateTimeOfNextMaintainance= new DateTime(2022,12,12),
                    ManufacturerSerialNumber = "2022/321534/34235",
                    EmailNotification = true,
                    RoomId = 1
                },            
                new Product() {
                    Id = 3,
                    Name = "Signal Pro 500",
                    Manufacturer = "ATMAT",
                    AdditionalDescription = "3D Printer",
                    DateTimeOfBuy = new DateTime(2022,6,12),
                    DateTimeOfEndOfGuarantee = new DateTime(2023,6,12),
                    DateTimeOfNextMaintainance= new DateTime(2022,12,12),
                    ManufacturerSerialNumber = "2022/321534/34236",
                    EmailNotification = true,
                    RoomId = 2
                }

            };
        }

        public Task CreateProduct(Product product)

        {
            _products.Add(product);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Product>> GetAllProducts()
        {
            return Task.FromResult<IEnumerable<Product>>(_products);
        }

        public Task<Product?> GetProductById(int id)
        {
            return Task.FromResult(_products.Find(x => x.Id == id));
        }

        public Task<IEnumerable<Product>> GetProductsByRoomId(int id)
        {
            return Task.FromResult<IEnumerable<Product>>(_products.FindAll(x => x.RoomId == id));
        }
    }
}
