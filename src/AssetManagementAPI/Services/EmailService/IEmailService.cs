using AssetManagementAPI.Model.EmailServiceModel;

namespace AssetManagementAPI.Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}
