using AssetManagement.Core.Entities;

namespace AssetManagement.Core.Interfaces
{
    public interface IMailService
    {
        Task<bool> SendAsync(MailData mailData, CancellationToken ct);
    }
}
