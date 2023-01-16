using AssetManagementAPI.Model.EmailServiceModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailSettingsController : ControllerBase
    {
        private readonly IConfiguration _config;

        public EmailSettingsController(IConfiguration configuration)
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
