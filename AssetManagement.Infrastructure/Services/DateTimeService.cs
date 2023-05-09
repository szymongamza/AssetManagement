using AssetManagement.Application.Interfaces;

namespace AssetManagement.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime UtcNow => DateTime.UtcNow;
}