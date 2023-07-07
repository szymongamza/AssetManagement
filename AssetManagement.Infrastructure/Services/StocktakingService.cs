

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

        var assetOnList = stocktaking.AssetStocktakings.FirstOrDefault(x=> x.Asset.QrCode == guid);

        if(assetOnList == null)
        {
            var asset = await _assetRepository.FindByQrCodeAsync(guid,token);
            asset.RoomId = stocktaking.RoomId;

            await _assetRepository.UpdateAsync(asset, token);

            stocktaking.Assets.Add(asset);
            await _stocktakingRepository.UpdateAsync(stocktaking, token);

        }

        stocktaking.AssetStocktakings.FirstOrDefault(x=>x.Asset.QrCode == guid).IsScanned = true;
        stocktaking.AssetStocktakings.FirstOrDefault(x=>x.Asset.QrCode == guid).ScannedTime = _dateTimeService.UtcNow;

        await _stocktakingRepository.UpdateAsync(stocktaking,token);

        return new StocktakingResponse(stocktaking);
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
