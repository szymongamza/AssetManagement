using AssetManagement.Application.Interfaces.Services;
using AssetManagement.Application.Resources;
using AssetManagement.Application.Resources.Faculty;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Api.Controllers;

public class FacultyController : BaseApiController
{
    private readonly IFacultyService _facultyService;
    private readonly IMapper _mapper;

    public FacultyController(IFacultyService facultyService, IMapper mapper)
    {
        _facultyService = facultyService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(QueryResultResource<FacultyResource>), 200)]
    public async Task<QueryResultResource<FacultyResource>> ListAsync([FromQuery] FacultyQueryResource query, CancellationToken token)
    {
        var facultyQuery = _mapper.Map<FacultyQueryResource, FacultyQuery>(query);
        var queryResult = await _facultyService.ListAsync(facultyQuery,token);

        var resource = _mapper.Map<QueryResult<Faculty>, QueryResultResource<FacultyResource>>(queryResult);
        return resource;
    }
}