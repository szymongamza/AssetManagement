using AssetManagement.Core.Entities;

namespace AssetManagement.Core.Interfaces
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product?> GetProductById(int id);
        Task CreateProduct(Product product);
        Task <IEnumerable<Product>> GetProductsByRoomId(int id);

    }
}
