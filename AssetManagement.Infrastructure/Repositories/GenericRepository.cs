using AssetManagement.Application.Interfaces;
using AssetManagement.Domain.Common;
using AssetManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly AssetManagementContext _dbContext;

    public GenericRepository(AssetManagementContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        return entity;
    }

    public Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<List<T>?> GetAllAsync()
    {
        return await _dbContext
            .Set<T>()
            .ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<List<T>?> GetPagedResponseAsync(int pageNumber, int pageSize)
    {
        return await _dbContext
            .Set<T>()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync();
    }

    public Task UpdateAsync(T entity)
    {
        T? exist = _dbContext.Set<T>().Find(entity.Id);
        if (exist != null)
        {
            _dbContext.Entry(exist).CurrentValues.SetValues(entity);
        }
        return Task.CompletedTask;
    }
}