

using AssetManagement.Application.Interfaces.Repositories;
using AssetManagement.Application.Interfaces.Services;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Common.Responses;
using AssetManagement.Domain.Entities;
using AssetManagement.Domain.Enums;
using AssetManagement.Infrastructure.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace AssetManagement.Infrastructure.Services;
public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IFacultyRepository _faultyRepository;
    private readonly IMemoryCache _memoryCache;

    public DepartmentService(IDepartmentRepository departmentRepository, IMemoryCache memoryCache, IFacultyRepository faultyRepository)
    {
        _departmentRepository = departmentRepository;
        _memoryCache = memoryCache;
        _faultyRepository = faultyRepository;
    }

    public async Task<QueryResult<Department>?> ListAsync(DepartmentQuery query, CancellationToken token)
    {
        string cacheKey = GetCacheKeyForDepartmentQuery(query);

        var departments = await _memoryCache.GetOrCreateAsync(cacheKey, (entry) =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2);
            return _departmentRepository.ToListAsync(query, token);
        });

        return departments;
    }

    public async Task<DepartmentResponse> AddAsync(Department department, CancellationToken token)
    {
        var existingFaculty = await _faultyRepository.FindByIdAsync(department.FacultyId, token);
        if (existingFaculty == null)
        {
            return new DepartmentResponse("Invalid faculty.");
        }
        try
        {
            await _departmentRepository.AddAsync(department, token);

            return new DepartmentResponse(department);
        }
        catch (Exception ex)
        {
            return new DepartmentResponse($"An error occurred when adding the department: {ex.Message}");
        }
    }

    public async Task<DepartmentResponse> UpdateAsync(int id, Department department, CancellationToken token)
    {
        var existingDepartment = await _departmentRepository.FindByIdAsync(id, token);

        if (existingDepartment == null)
        {
            return new DepartmentResponse("Department not found");
        }
        var existingFaculty = await _faultyRepository.FindByIdAsync(department.FacultyId, token);
        if (existingFaculty == null)
        {
            return new DepartmentResponse("Invalid faculty.");
        }

        existingDepartment.FacultyId = department.FacultyId;
        existingDepartment.Code = department.Code;
        existingDepartment.Name = department.Name;

        try
        {
            await _departmentRepository.UpdateAsync(existingDepartment, token);
            return new DepartmentResponse(existingDepartment);
        }
        catch (Exception ex)
        {
            return new DepartmentResponse($"An error occurred when updating the department: {ex.Message}");
        }
    }

    public async Task<DepartmentResponse> DeleteAsync(int id, CancellationToken token)
    {
        var existingDepartment = await _departmentRepository.FindByIdAsync(id, token);

        if (existingDepartment == null)
        {
            return new DepartmentResponse("Department not found");
        }

        try
        {
            await _departmentRepository.DeleteAsync(existingDepartment, token);
            return new DepartmentResponse(existingDepartment);
        }
        catch (Exception ex)
        {
            return new DepartmentResponse($"An error occurred when deleting the department: {ex.Message}");
        }
    }

    private string GetCacheKeyForDepartmentQuery(DepartmentQuery query)
    {
        string key = CacheKeys.DepartmentList.ToString();
        key = string.Concat(key, "_", query.Page, "_", query.ItemsPerPage);
        return key;
    }
}
