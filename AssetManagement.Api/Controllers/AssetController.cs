
using AssetManagement.Application.Interfaces.Services;
using AssetManagement.Application.Resources.Asset;
using AssetManagement.Application.Resources;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Api.Controllers;

public class AssetController : BaseApiController
{
    private readonly IAssetService _assetService;
    private readonly IMapper _mapper;

    public AssetController(IAssetService assetService, IMapper mapper)
    {
        _assetService = assetService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(QueryResultResource<AssetResource>), 200)]
    public async Task<QueryResultResource<AssetResource>> ListAsync([FromQuery] AssetQueryResource query, CancellationToken token)
    {
        var assetQuery = _mapper.Map<AssetQueryResource, AssetQuery>(query);
        var queryResult = await _assetService.ListAsync(assetQuery, token);

        var resource = _mapper.Map<QueryResult<Asset>, QueryResultResource<AssetResource>>(queryResult);
        return resource;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AssetResource), 201)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> PostAsync([FromBody] SaveAssetResource resource, CancellationToken token)
    {
        var asset = _mapper.Map<SaveAssetResource, Asset>(resource);
        var result = await _assetService.AddAsync(asset, token);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var assetResource = _mapper.Map<Asset, AssetResource>(result.Resource);
        return Ok(assetResource);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(AssetResource), 201)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAssetResource resource, CancellationToken token)
    {
        var asset = _mapper.Map<SaveAssetResource, Asset>(resource);
        var result = await _assetService.UpdateAsync(id, asset, token);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var assetResource = _mapper.Map<Asset, AssetResource>(result.Resource);
        return Ok(assetResource);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(AssetResource), 200)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> DeleteAsync(int id, CancellationToken token)
    {
        var result = await _assetService.DeleteAsync(id, token);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var assetResource = _mapper.Map<Asset, AssetResource>(result.Resource);
        return Ok(assetResource);
    }
}
