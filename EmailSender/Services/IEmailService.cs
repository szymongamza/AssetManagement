using EmailSender.Models;

namespace EmailSender.Services
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}
