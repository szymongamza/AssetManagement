

using AssetManagement.Application.Interfaces.Repositories;
using AssetManagement.Application.Interfaces.Services;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Common.Responses;
using AssetManagement.Domain.Entities;
using AssetManagement.Domain.Enums;

namespace AssetManagement.Infrastructure.Services;
public class StocktakingService : IStocktakingService
{
    private readonly IStocktakingRepository _stocktakingRepository;
    private readonly IRoomRepository _roomRepository;
    private readonly IAssetRepository _assetRepository;
    private readonly IDateTimeService _dateTimeService;

    public StocktakingService(IStocktakingRepository stocktakingRepository, IRoomRepository roomRepository, IAssetRepository assetRepository, IDateTimeService dateTimeService)
    {
        _stocktakingRepository = stocktakingRepository;
        _roomRepository = roomRepository;
        _assetRepository = assetRepository;
        _dateTimeService = dateTimeService;
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

    public async Task<StocktakingResponse> RegisterAssetAsync(int id, Guid guid, CancellationToken token)
    {
        var stocktaking = await _stocktakingRepository.FindByIdAsync(id, token);
        if(stocktaking == null)
        {
            return new StocktakingResponse("There is no such stocktaking session.");
        }
        if (stocktaking.IsClosed)
        {
            return new StocktakingResponse("This stocktaking session is closed.");
        }

        var asset = await  _assetRepository.FindByQrCodeAsync(guid, token);
        var assetStock = asset.AssetStocktakings.FirstOrDefault(x => x.StocktakingId == id);

        if (assetStock is not null)
        {
            assetStock.IsScanned = true;
            assetStock.ScannedTime = _dateTimeService.UtcNow;
        }

        if (asset.RoomId != stocktaking.RoomId)
        {
            assetStock.ChangedRoom = true;
            assetStock.PreviousRoomId = asset.RoomId;
            asset.RoomId = stocktaking.RoomId;
            asset.Status = AssetStatus.VerificationNeeded;
        }

        await _assetRepository.UpdateAsync(asset, token);

        return new StocktakingResponse(stocktaking);
    }

    public async Task<StocktakingResponse> CloseStocktakingAsync(int id, CancellationToken token)
    {
        var stocktaking = await _stocktakingRepository.FindByIdAsync(id, token);
        if (stocktaking == null)
        {
            return new StocktakingResponse("There is no such stocktaking session.");
        }
        if (stocktaking.IsClosed)
        {
            return new StocktakingResponse("This stocktaking session is closed.");
        }

        stocktaking.IsClosed = true;

        await _stocktakingRepository.UpdateAsync(stocktaking, token);

        return new StocktakingResponse(stocktaking);
    }

    public async Task<StocktakingResponse> DeleteAsync(int id, CancellationToken token)
    {
        var stocktaking = await _stocktakingRepository.FindByIdAsync(id, token);
        if (stocktaking == null)
        {
            return new StocktakingResponse("There is no such stocktaking session.");
        }

        await _stocktakingRepository.DeleteAsync(stocktaking, token);

        return new StocktakingResponse(stocktaking);
    }
}
