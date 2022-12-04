using EmailSender.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmailSender.SettingsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly IConfiguration _config;

        public SettingsController(IConfiguration configuration)
        {
            _config = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var settings = new Settings();
            settings.EmailHost = _config.GetSection("EmailHost").Value;
            settings.EmailUsername = _config.GetSection("EmailUsername").Value;
            settings.SmtpConfigured = _config.GetSection("SmtpConfigured").Value;
            settings.EmailPassword = "****";
            return Ok(settings);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Settings settings)
        {
            _config.GetSection("EmailHost").Value = settings.EmailHost;
            _config.GetSection("EmailUsername").Value = settings.EmailUsername;
            _config.GetSection("SmtpConfigured").Value = settings.SmtpConfigured;
            _config.GetSection("EmailPassword").Value = settings.EmailPassword;
            return Ok();

        }
    }
}
