using AssetManagement.Application.Interfaces.Services;
using AssetManagement.Application.Resources.User;
using AssetManagement.Application.Resources;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Api.Controllers;

public class UserController : BaseApiController
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(QueryResultResource<UserResource>), 200)]
    public async Task<QueryResultResource<UserResource>> ListAsync([FromQuery] UserQueryResource query, CancellationToken token)
    {
        var userQuery = _mapper.Map<UserQueryResource, UserQuery>(query);
        var queryResult = await _userService.ListAsync(userQuery, token);

        var resource = _mapper.Map<QueryResult<User>, QueryResultResource<UserResource>>(queryResult);
        return resource;
    }

    [HttpPost]
    [ProducesResponseType(typeof(UserResource), 201)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource, CancellationToken token)
    {
        var user = _mapper.Map<SaveUserResource, User>(resource);
        var result = await _userService.AddAsync(user, token);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var userResource = _mapper.Map<User, UserResource>(result.Resource);
        return Ok(userResource);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(UserResource), 201)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserResource resource, CancellationToken token)
    {
        var user = _mapper.Map<SaveUserResource, User>(resource);
        var result = await _userService.UpdateAsync(id, user, token);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var userResource = _mapper.Map<User, UserResource>(result.Resource);
        return Ok(userResource);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(UserResource), 200)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> DeleteAsync(int id, CancellationToken token)
    {
        var result = await _userService.DeleteAsync(id, token);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var userResource = _mapper.Map<User, UserResource>(result.Resource);
        return Ok(userResource);
    }
}