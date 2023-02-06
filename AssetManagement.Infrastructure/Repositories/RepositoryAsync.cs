using AssetManagement.Application.Common.Interfaces.Repositories;
using AssetManagement.Domain.Contracts;
using AssetManagement.Domain.Entities;

namespace AssetManagement.Infrastructure.Repositories
{

    public class RepositoryAsync<T,TId> : IRepositoryAsync<T,TId> where T : Entity<TId>
    {
        public async Task<T?> GetByIdAsync(TId id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>?> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>?> GetPagedResponseAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
