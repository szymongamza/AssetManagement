using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task<T> AddAsync(T entity);

        public Task DeleteAsync(T entity);

        public Task<List<T>?> GetAllAsync();

        public Task<T?> GetByIdAsync(int id);

        public Task<List<T>?> GetPagedResponseAsync(int pageNumber, int pageSize);

        public Task UpdateAsync(T entity);
    }
}
