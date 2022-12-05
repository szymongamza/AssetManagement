using EmailSender.Dtos;
using EmailSender.Models;
using EmailSender.Services;
using System.Text.Json;

namespace EmailSender.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IEmailService _emailService;

        public EventProcessor(IServiceScopeFactory scopeFactory, IEmailService emailService)
        {
            _scopeFactory = scopeFactory;
            _emailService = emailService;
        }
        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.EmailMaintenanceNotification:
                    PrepareEmailAndSend(message);
                    break;
                default:
                    break;

            }

        }

        private void PrepareEmailAndSend(string message)
        {
            using (var scope = _scopeFactory.CreateScope())
            {

                var request = JsonSerializer.Deserialize<EmailDto>(message);

                try
                {
                    _emailService.SendEmail(request);
                }
                catch (Exception ex)
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
                case "EmailMaintenanceNotification":
                    return EventType.EmailMaintenanceNotification;
                default:
                    return EventType.Undetermined;
            }
        }
    }
    enum EventType
    {
        EmailMaintenanceNotification,
        Undetermined
    }
}