

using System.Reflection.Metadata;
using AssetManagement.Domain.Contracts;

namespace AssetManagement.Application.Common.Interfaces.Repositories
{
    public interface IRepositoryAsync<T, in TId> where T : class, IEntity<TId>
    {
        Task<T?> GetByIdAsync(TId id);

        Task<List<T>?> GetAllAsync();

        Task<List<T>?> GetPagedResponseAsync(int pageNumber, int pageSize);

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
