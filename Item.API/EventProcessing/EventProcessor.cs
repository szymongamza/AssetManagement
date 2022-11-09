using System.Text.Json;
using AutoMapper;
using Item.API.Data;
using Item.API.Dtos;
using Item.API.Model;

namespace Item.API.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;

        public EventProcessor(IServiceScopeFactory scopeFactory, IMapper mapper)
        {
            _scopeFactory = scopeFactory;
            _mapper = mapper;
        }
        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.RoomPublished:
                    addRoom(message);
                    break;
                default:
                    break;
                
            }

        }

        private async void addRoom(string message)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<IProductRepo>();

                var roomPublishedDto = JsonSerializer.Deserialize<RoomPublishedDto>(message);

                try
                {
                    var room = _mapper.Map<Room>(roomPublishedDto);
                    if (!repo.ExternalRoomExists(room.ExternalID)){
                        await repo.CreateRoom(room);
                    }
                    else
                    {
                        Console.WriteLine("==EventProcessor==: Room already exists.");
                    }

                }catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private EventType DetermineEvent(string message)
        {
            var eventType = JsonSerializer.Deserialize<GenericEventDto>(message);

            switch (eventType.Event)
            {
                case "Room_Published":
                    return EventType.RoomPublished;
                default:
                    return EventType.Undetermined;
            }
        }
    }
    enum EventType
    {
        RoomPublished,
        Undetermined
    }
}
