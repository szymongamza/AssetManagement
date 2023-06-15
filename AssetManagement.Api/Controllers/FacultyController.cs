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

    [HttpPost]
    [ProducesResponseType(typeof(FacultyResource), 201)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> PostAsync([FromBody] SaveFacultyResource resource, CancellationToken token)
    {
        var faculty = _mapper.Map<SaveFacultyResource, Faculty>(resource);
        var result = await _facultyService.AddAsync(faculty, token);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var facultyResource = _mapper.Map<Faculty, FacultyResource>(result.Resource);
        return Ok(facultyResource);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(FacultyResource), 201)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveFacultyResource resource, CancellationToken token)
    {
        var faculty = _mapper.Map<SaveFacultyResource, Faculty>(resource);
        var result = await _facultyService.UpdateAsync(id, faculty, token);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var facultyResource = _mapper.Map<Faculty, FacultyResource>(result.Resource);
        return Ok(facultyResource);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(FacultyResource), 200)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> DeleteAsync(int id, CancellationToken token)
    {
        var result = await _facultyService.DeleteAsync(id,token);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var facultyResource = _mapper.Map<Faculty, FacultyResource>(result.Resource);
        return Ok(facultyResource);
    }
}