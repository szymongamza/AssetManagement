using AssetManagement.Application.Interfaces.Services;
using AssetManagement.Application.Resources;
using AssetManagement.Application.Resources.Department;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Api.Controllers;

public class DepartmentController : BaseApiController
{
    private readonly IDepartmentService _departmentService;
    private readonly IMapper _mapper;

    public DepartmentController(IDepartmentService departmentService, IMapper mapper)
    {
        _departmentService = departmentService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(QueryResultResource<DepartmentResource>), 200)]
    public async Task<QueryResultResource<DepartmentResource>> ListAsync([FromQuery] DepartmentQueryResource query, CancellationToken token)
    {
        var departmentQuery = _mapper.Map<DepartmentQueryResource, DepartmentQuery>(query);
        var queryResult = await _departmentService.ListAsync(departmentQuery, token);

        var resource = _mapper.Map<QueryResult<Department>, QueryResultResource<DepartmentResource>>(queryResult);
        return resource;
    }

    [HttpPost]
    [ProducesResponseType(typeof(DepartmentResource), 201)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> PostAsync([FromBody] SaveDepartmentResource resource, CancellationToken token)
    {
        var department = _mapper.Map<SaveDepartmentResource, Department>(resource);
        var result = await _departmentService.AddAsync(department, token);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var departmentResource = _mapper.Map<Department, DepartmentResource>(result.Resource);
        return Ok(departmentResource);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(DepartmentResource), 201)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDepartmentResource resource, CancellationToken token)
    {
        var department = _mapper.Map<SaveDepartmentResource, Department>(resource);
        var result = await _departmentService.UpdateAsync(id, department, token);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var departmentResource = _mapper.Map<Department, DepartmentResource>(result.Resource);
        return Ok(departmentResource);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(DepartmentResource), 200)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> DeleteAsync(int id, CancellationToken token)
    {
        var result = await _departmentService.DeleteAsync(id, token);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var departmentResource = _mapper.Map<Department, DepartmentResource>(result.Resource);
        return Ok(departmentResource);
    }
}