using AssetManagementAPI.Model;

namespace AssetManagementAPI.Data
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product?> GetProductById(int id);
        Task CreateProduct(Product product);
        Task <IEnumerable<Product>> GetProductsByRoomId(int id);

    }
}
