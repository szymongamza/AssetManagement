using AssetManagement.Application.Interfaces.Repositories;
using AssetManagement.Domain.Common;
using AssetManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly AssetManagementContext _dbContext;

    protected GenericRepository(AssetManagementContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T> AddAsync(T entity, CancellationToken token)
    {
        await _dbContext.Set<T>().AddAsync(entity,token);
        await _dbContext.SaveChangesAsync(token);
        return entity;
    }

    public async Task DeleteAsync(T entity, CancellationToken token)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync(token);
    }

    public async Task<List<T>> ToListAsync(CancellationToken token)
    {
        return await _dbContext
            .Set<T>()
            .AsNoTracking()
            .ToListAsync(token);
    }

    public async Task<T> FindByIdAsync(int id, CancellationToken token)
    {
        return await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id, token);
    }

    public async Task UpdateAsync(T entity, CancellationToken token)
    {
        T exist = await _dbContext.Set<T>().FirstOrDefaultAsync(x=> x.Id == entity.Id, token);
        if (exist != null)
        {
            _dbContext.Entry(exist).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync(token);
        }
    }
}