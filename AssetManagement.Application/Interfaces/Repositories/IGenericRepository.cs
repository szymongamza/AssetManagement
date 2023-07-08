using AssetManagement.Domain.Common;

namespace AssetManagement.Application.Interfaces.Repositories;

public interface IGenericRepository<T> where T : BaseEntity
{
    public Task<T> AddAsync(T entity, CancellationToken token);

    public Task DeleteAsync(T entity, CancellationToken token);

    public Task<List<T>> ToListAsync(CancellationToken token);

    public Task<T> FindByIdAsync(int id, CancellationToken token);

    public Task UpdateAsync(T entity, CancellationToken token);
}