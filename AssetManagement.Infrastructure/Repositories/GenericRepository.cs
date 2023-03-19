using AssetManagement.Application.Interfaces;
using AssetManagement.Application.Models;
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
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
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

    public async Task<int> GetCount()
    {
        return await _dbContext.Set<T>().CountAsync();
    }

    public async Task<PaginatedList<T>?> GetPagedResponseAsync(int pageNumber, int pageSize)
    {

        var pagedList = await _dbContext
            .Set<T>()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync();
        var count = _dbContext.Set<T>().Count();

        return new PaginatedList<T>(pagedList, count, pageNumber,pageSize);
    }

    public async Task UpdateAsync(T entity)
    {
        T? exist = _dbContext.Set<T>().Find(entity.Id);
        if (exist != null)
        {
            _dbContext.Entry(exist).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}