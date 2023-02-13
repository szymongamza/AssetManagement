using AssetManagement.Application.Identity.Authentication.Queries.Login;
using AssetManagement.Application.Identity.Authentication.Commands.Register;
using AssetManagement.Contracts;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AssetManagement.Application.Identity.Users.Queries.GetAll;

namespace AssetManagement.Api.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public UserController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var command = new GetAllQuery();
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
