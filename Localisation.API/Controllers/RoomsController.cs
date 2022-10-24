using AutoMapper;
using Localisation.API.Data;
using Localisation.API.Dtos;
using Localisation.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Localisation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomRepo _roomRepo;
        private readonly IBuildingRepo _buildingRepo;
        private readonly IMapper _mapper;

        public RoomsController(IRoomRepo roomRepo,IBuildingRepo buildingRepo, IMapper mapper)
        {
            _roomRepo = roomRepo;
            _buildingRepo = buildingRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomReadDto>>> GetRooms()
        {
            var rooms = await _roomRepo.GetAllRooms();
            return Ok(_mapper.Map<IEnumerable<RoomReadDto>>(rooms));
        }

        [HttpGet("{id}", Name = "GetRoomById")]
        public async Task<ActionResult<IEnumerable<RoomReadDto>>> GetRoomById(int id)
        {
            var room = await _roomRepo.GetRoomById(id);
            if (room != null)
                return Ok(_mapper.Map<RoomReadDto>(room));
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> CreateRoom(RoomCreateDto room)
        {
            var building = await _buildingRepo.GetBuildingById(room.BuildingId);
            if (building == null)
            {
                return Content(); //TODO
            }
            var roomModel = _mapper.Map<Room>(room);
            await _roomRepo.CreateRoom(roomModel);

            var roomReadDto = _mapper.Map<RoomReadDto>(roomModel);
            return CreatedAtRoute(nameof(GetRoomById), new { Id = roomReadDto.Id }, roomReadDto);
        }
    }
}
