using AssetManagement.Application.Interfaces.Services;

namespace AssetManagement.Infrastructure.Services;

public class DateTimeService : IDateTimeService
{
    public DateTime UtcNow => DateTime.UtcNow;
}