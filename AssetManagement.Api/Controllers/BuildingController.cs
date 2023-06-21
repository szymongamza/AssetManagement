using AssetManagement.Application.Interfaces.Services;
using AssetManagement.Application.Resources.Building;
using AssetManagement.Application.Resources;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Api.Controllers;
public class BuildingController : BaseApiController
{
    private readonly IBuildingService _buildingService;
    private readonly IMapper _mapper;

    public BuildingController(IBuildingService buildingService, IMapper mapper)
    {
        _buildingService = buildingService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(QueryResultResource<BuildingResource>), 200)]
    public async Task<QueryResultResource<BuildingResource>> ListAsync([FromQuery] BuildingQueryResource query, CancellationToken token)
    {
        var buildingQuery = _mapper.Map<BuildingQueryResource, BuildingQuery>(query);
        var queryResult = await _buildingService.ListAsync(buildingQuery, token);

        var resource = _mapper.Map<QueryResult<Building>, QueryResultResource<BuildingResource>>(queryResult);
        return resource;
    }

    [HttpPost]
    [ProducesResponseType(typeof(BuildingResource), 201)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> PostAsync([FromBody] SaveBuildingResource resource, CancellationToken token)
    {
        var building = _mapper.Map<SaveBuildingResource, Building>(resource);
        var result = await _buildingService.AddAsync(building, token);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var buildingResource = _mapper.Map<Building, BuildingResource>(result.Resource);
        return Ok(buildingResource);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(BuildingResource), 201)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveBuildingResource resource, CancellationToken token)
    {
        var building = _mapper.Map<SaveBuildingResource, Building>(resource);
        var result = await _buildingService.UpdateAsync(id, building, token);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var buildingResource = _mapper.Map<Building, BuildingResource>(result.Resource);
        return Ok(buildingResource);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(BuildingResource), 200)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> DeleteAsync(int id, CancellationToken token)
    {
        var result = await _buildingService.DeleteAsync(id, token);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var buildingResource = _mapper.Map<Building, BuildingResource>(result.Resource);
        return Ok(buildingResource);
    }
}