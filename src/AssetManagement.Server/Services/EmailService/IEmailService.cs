using AssetManagement.Server.Model.EmailServiceModel;

namespace AssetManagement.Server.Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}
