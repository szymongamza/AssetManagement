

using AssetManagement.Application.Interfaces.Repositories;
using AssetManagement.Application.Interfaces.Services;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Common.Responses;
using AssetManagement.Domain.Entities;

namespace AssetManagement.Infrastructure.Services;
public class StocktakingService : IStocktakingService
{
    private readonly IStocktakingRepository _stocktakingRepository;
    private readonly IRoomRepository _roomRepository;

    public StocktakingService(IStocktakingRepository stocktakingRepository, IRoomRepository roomRepository)
    {
        _stocktakingRepository = stocktakingRepository;
        _roomRepository = roomRepository;
    }

    public async Task<QueryResult<Stocktaking>> ListAsync(StocktakingQuery query, CancellationToken token)
    {
        var stocktakings = await _stocktakingRepository.ToListAsync(query, token);

        return stocktakings;
    }

    public async Task<StocktakingResponse> NewStocktakingAsync(int roomId, CancellationToken token)
    {
        var existingRoom = await _roomRepository.FindByIdAsync(roomId, token);
        if (existingRoom == null)
        {
            return new StocktakingResponse("There is no such room.");
        }

        try
        {
            var stockTaking = new Stocktaking { RoomId = existingRoom.Id, Assets =  existingRoom.Assets};
            await _stocktakingRepository.AddAsync(stockTaking, token);

            return new StocktakingResponse(stockTaking);
        }
        catch (Exception ex)
        {
            return new StocktakingResponse($"An error occurred when c: {ex.Message}");
        }
    }

    public async Task<StocktakingResponse> RegisterAssetAsync(Guid guid, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task<StocktakingResponse> CloseStocktakingAsync(int id, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task<StocktakingResponse> DeleteAsync(int id, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
