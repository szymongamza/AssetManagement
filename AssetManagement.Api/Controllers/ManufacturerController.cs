using AssetManagement.Application.Interfaces.Services;
using AssetManagement.Application.Resources.Manufacturer;
using AssetManagement.Application.Resources;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Api.Controllers;

public class ManufacturerController : BaseApiController
{
    private readonly IManufacturerService _manufacturerService;
    private readonly IMapper _mapper;

    public ManufacturerController(IManufacturerService manufacturerService, IMapper mapper)
    {
        _manufacturerService = manufacturerService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(QueryResultResource<ManufacturerResource>), 200)]
    public async Task<QueryResultResource<ManufacturerResource>> ListAsync([FromQuery] ManufacturerQueryResource query, CancellationToken token)
    {
        var manufacturerQuery = _mapper.Map<ManufacturerQueryResource, ManufacturerQuery>(query);
        var queryResult = await _manufacturerService.ListAsync(manufacturerQuery, token);

        var resource = _mapper.Map<QueryResult<Manufacturer>, QueryResultResource<ManufacturerResource>>(queryResult);
        return resource;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ManufacturerResource), 201)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> PostAsync([FromBody] SaveManufacturerResource resource, CancellationToken token)
    {
        var manufacturer = _mapper.Map<SaveManufacturerResource, Manufacturer>(resource);
        var result = await _manufacturerService.AddAsync(manufacturer, token);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var manufacturerResource = _mapper.Map<Manufacturer, ManufacturerResource>(result.Resource);
        return Ok(manufacturerResource);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ManufacturerResource), 201)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveManufacturerResource resource, CancellationToken token)
    {
        var manufacturer = _mapper.Map<SaveManufacturerResource, Manufacturer>(resource);
        var result = await _manufacturerService.UpdateAsync(id, manufacturer, token);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var manufacturerResource = _mapper.Map<Manufacturer, ManufacturerResource>(result.Resource);
        return Ok(manufacturerResource);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ManufacturerResource), 200)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> DeleteAsync(int id, CancellationToken token)
    {
        var result = await _manufacturerService.DeleteAsync(id, token);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var manufacturerResource = _mapper.Map<Manufacturer, ManufacturerResource>(result.Resource);
        return Ok(manufacturerResource);
    }
}