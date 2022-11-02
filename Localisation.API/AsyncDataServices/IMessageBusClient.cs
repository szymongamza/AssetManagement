using Localisation.API.Dtos;

namespace Localisation.API.AsyncDataServices
{
    public interface IMessageBusClient
    {
        void PublishNewRoom(RoomPublishedDto roomPublishedDto);
    }
}
