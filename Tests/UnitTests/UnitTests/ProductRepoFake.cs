using Localisation.API.Data;
using Localisation.API.Model;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
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
                    RoomId = 2
                }

            };
        }

#pragma warning disable CS1998 // Metoda asynchroniczna nie zawiera operatorów „await” i zostanie uruchomiona synchronicznie
        public async Task CreateProduct(Product product)

        {
            _products.Add(product);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return _products;
        }

        public async Task<Product?> GetProductById(int id)
        {
            return _products.Find(x => x.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsByRoomId(int id)
        {
            return _products.FindAll(x => x.RoomId == id);
        }
#pragma warning restore CS1998 // Metoda asynchroniczna nie zawiera operatorów „await” i zostanie uruchomiona synchronicznie
    }
}
