﻿using AssetManagement.Core.Entities;
using AssetManagement.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Infrastructure.Data.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext _context;

        public ProductRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product?> GetProductById(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<IEnumerable<Product>> GetProductsByRoomId(int id)
        {
            var products = await _context.Products.Where(x => x.RoomId == id).ToListAsync();
            return products;
        }
    }
}
