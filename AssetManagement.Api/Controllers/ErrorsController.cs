using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Api.Controllers
{
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        private IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
#pragma warning disable CS8602 // Wyłuskanie odwołania, które może mieć wartość null.
            return Problem(exception.ToString());
#pragma warning restore CS8602 // Wyłuskanie odwołania, które może mieć wartość null.
        }
    }
}
