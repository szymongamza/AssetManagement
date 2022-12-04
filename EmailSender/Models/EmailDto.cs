using MimeKit.Cryptography;

namespace EmailSender.Models
{
    public class EmailDto
    {
        public string? To { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
    }
}
