using AssetManagement.Application.Interfaces.Services;
using AssetManagement.Application.Resources.Asset;
using AssetManagement.Application.Resources;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;
using AssetManagement.Infrastructure.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AssetManagement.Application.Resources.Stocktaking;
using AssetManagement.Application.Resources.Building;
using AssetManagement.Application.Resources.Manufacturer;

namespace AssetManagement.Api.Controllers;

public class StocktakingController : BaseApiController
{
    private readonly IStocktakingService _stocktakingService;
    private readonly IMapper _mapper;

    public StocktakingController(IStocktakingService stocktakingService, IMapper mapper)
    {
        _stocktakingService = stocktakingService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(QueryResultResource<StocktakingResource>), 200)]
    public async Task<QueryResultResource<StocktakingResource>> ListAsync([FromQuery] StocktakingQueryResource query, CancellationToken token)
    {
        var stocktakingQuery = _mapper.Map<StocktakingQueryResource, StocktakingQuery>(query);
        var queryResult = await _stocktakingService.ListAsync(stocktakingQuery, token);

        var resource = _mapper.Map<QueryResult<Stocktaking>, QueryResultResource<StocktakingResource>>(queryResult);
        return resource;
    }

    [HttpPost]
    [ProducesResponseType(typeof(StocktakingResource), 201)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> NewStocktakingAsync(int roomId, CancellationToken token)
    {
        var result = await _stocktakingService.NewStocktakingAsync(roomId, token);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var stocktakingResource = _mapper.Map<Stocktaking, StocktakingResource>(result.Resource);
        return Ok(stocktakingResource);
    }

    [HttpPost]
    [Route("{id}/registerAsset")]
    [ProducesResponseType(typeof(StocktakingResource), 201)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> RegisterAssetAsync(int id, Guid assetGuid, CancellationToken token)
    {
        var result = await _stocktakingService.RegisterAssetAsync(id, assetGuid, token);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var stocktakingResource = _mapper.Map<Stocktaking, StocktakingResource>(result.Resource);

        return Ok(stocktakingResource);
    }

    [HttpPost]
    [Route("{id}/closeStocktaking")]
    [ProducesResponseType(typeof(StocktakingResource), 201)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> CloseStocktakingAsync(int id, CancellationToken token)
    {
        var result = await _stocktakingService.CloseStocktakingAsync(id, token);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var stocktakingResource = _mapper.Map<Stocktaking, StocktakingResource>(result.Resource);

        return Ok(stocktakingResource);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(StocktakingResource), 200)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> DeleteAsync(int id, CancellationToken token)
    {
        var result = await _stocktakingService.DeleteAsync(id, token);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var stocktakingResource = _mapper.Map<Stocktaking, StocktakingResource>(result.Resource);
        return Ok(stocktakingResource);
    }

}
