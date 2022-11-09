using Item.API.Model;

namespace Item.API.Data
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task CreateProduct(Product product);
        Task CreateRoom(Room room);
        bool ExternalRoomExists(int externalRoomId);
        Task<IEnumerable<Room>> GetAllRooms();
    }
}
