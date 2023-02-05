using AssetManagement.Application.Common.Interfaces.Services;

namespace AssetManagement.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
