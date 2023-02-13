using AssetManagement.Application.Identity.Authentication.Commands.Register;
using AssetManagement.Application.Identity.Authentication.Queries.Login;
using AssetManagement.Contracts;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Api.Controllers.Identity
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);
            var authResult = await _mediator.Send(command);

            var response = _mapper.Map<RegisterResponse>(authResult);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var command = _mapper.Map<LoginQuery>(request);
            var response = await _mediator.Send(command);

            return Ok(response);
        }

    }
}
