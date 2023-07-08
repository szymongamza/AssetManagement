
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Common.Responses;
using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Interfaces.Services;
public interface IFacultyService
{
    Task<QueryResult<Faculty>> ListAsync(FacultyQuery query, CancellationToken token);
    Task<FacultyResponse> AddAsync(Faculty faculty, CancellationToken token);
    Task<FacultyResponse> UpdateAsync(int id, Faculty faculty, CancellationToken token);
    Task<FacultyResponse> DeleteAsync(int id, CancellationToken token);
}
