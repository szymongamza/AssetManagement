using AssetManagement.Application.Interfaces.Services;
using AssetManagement.Application.Resources.Room;
using AssetManagement.Application.Resources;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Api.Controllers;

public class RoomController : BaseApiController
{
    private readonly IRoomService _roomService;
    private readonly IMapper _mapper;

    public RoomController(IRoomService roomService, IMapper mapper)
    {
        _roomService = roomService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(QueryResultResource<RoomResource>), 200)]
    public async Task<QueryResultResource<RoomResource>> ListAsync([FromQuery] RoomQueryResource query, CancellationToken token)
    {
        var roomQuery = _mapper.Map<RoomQueryResource, RoomQuery>(query);
        var queryResult = await _roomService.ListAsync(roomQuery, token);

        var resource = _mapper.Map<QueryResult<Room>, QueryResultResource<RoomResource>>(queryResult);
        return resource;
    }

    [HttpPost]
    [ProducesResponseType(typeof(RoomResource), 201)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> PostAsync([FromBody] SaveRoomResource resource, CancellationToken token)
    {
        var room = _mapper.Map<SaveRoomResource, Room>(resource);
        var result = await _roomService.AddAsync(room, token);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var roomResource = _mapper.Map<Room, RoomResource>(result.Resource);
        return Ok(roomResource);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(RoomResource), 201)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRoomResource resource, CancellationToken token)
    {
        var room = _mapper.Map<SaveRoomResource, Room>(resource);
        var result = await _roomService.UpdateAsync(id, room, token);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var roomResource = _mapper.Map<Room, RoomResource>(result.Resource);
        return Ok(roomResource);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(RoomResource), 200)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> DeleteAsync(int id, CancellationToken token)
    {
        var result = await _roomService.DeleteAsync(id, token);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var roomResource = _mapper.Map<Room, RoomResource>(result.Resource);
        return Ok(roomResource);
    }
}
