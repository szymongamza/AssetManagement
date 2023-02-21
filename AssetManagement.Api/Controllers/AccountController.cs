using AssetManagement.Api.Dtos;
using AssetManagement.Application.Services;
using AssetManagement.Domain.Entities.Identity;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;
        private readonly ITokenService _tokenService;

        public AccountController(IMapper mapper, ITokenService tokenService, IIdentityService identityService)
        {
            _mapper = mapper;
            _tokenService = tokenService;
            _identityService = identityService;
        }

        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (CheckEmailExistAsync(registerDto.Email).Result.Value)
            {
                return BadRequest("Email exists");
            }
            var user = new AppUser
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.Email
            };
            var result = await _identityService.CreateAsync(user, registerDto.Password);
            if (!result.result.Succeeded)
            {
                return BadRequest(result.result.Errors);
            }
            else
            {
                return Ok(new UserDto
                {
                    UserId = result.userId!,
                    DisplayName = user.DisplayName,
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user)

                });
            }
        }
        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistAsync([FromQuery] string email)
        {
            return await _identityService.FindByEmailAsync(email) != null;
        }

        // [HttpPost("login")]
        // public async Task<IActionResult> Login(LoginRequest request)
        // {
        //     var command = _mapper.Map<LoginQuery>(request);
        //     var response = await _mediator.Send(command);
        //
        //     return Ok(response);
        // }

    }
}
