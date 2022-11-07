using Item.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Item.API.Data
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
                throw new ArgumentNullException(nameof(product));
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task CreateRoom(Room room)
        {
            if (room == null)
            {
                throw new ArgumentNullException(nameof(room));
            }
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }

        public bool ExternalRoomExists(int externalRoomId)
        {
            return _context.Rooms.Any(p => p.ExternalID == externalRoomId);
        }


    }
}
