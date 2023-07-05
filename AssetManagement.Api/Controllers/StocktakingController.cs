using AutoMapper;

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


}
