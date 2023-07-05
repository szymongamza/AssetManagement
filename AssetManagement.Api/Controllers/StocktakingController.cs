using AssetManagement.Application.Interfaces.Services;
using AssetManagement.Application.Resources.Asset;
using AssetManagement.Application.Resources;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;
using AssetManagement.Infrastructure.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AssetManagement.Application.Resources.Stocktaking;

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

    

}
