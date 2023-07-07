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
    public async Task<IActionResult> NewStocktakingAsync([FromBody]int roomId, CancellationToken token)
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
    [Route("{id:int}")]
    [ProducesResponseType(typeof(StocktakingResource), 201)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> RegisterAssetAsync(int id, [FromBody] Guid guid, CancellationToken token)
    {
        var result = await _stocktakingService.RegisterAssetAsync(id, guid, token);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var stocktakingResource = _mapper.Map<Stocktaking, StocktakingResource>(result.Resource);

        return Ok(stocktakingResource);
    }

}
