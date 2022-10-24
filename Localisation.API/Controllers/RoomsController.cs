using AutoMapper;
using Localisation.API.Data;
using Localisation.API.Dtos;
using Localisation.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Localisation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomRepo _repository;
        private readonly IMapper _mapper;

        public RoomsController(IRoomRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomReadDto>>> GetBuildings()
        {
            var rooms = await _repository.GetAllRooms();
            return Ok(_mapper.Map<IEnumerable<RoomReadDto>>(rooms));
        }

        [HttpGet("{id}", Name = "GetRoomById")]
        public async Task<ActionResult<IEnumerable<RoomReadDto>>> GetRoomById(int id)
        {
            var room = await _repository.GetRoomById(id);
            if (room != null)
                return Ok(_mapper.Map<RoomReadDto>(room));
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> CreateBuilding(RoomCreateDto room)
        {
            var roomModel = _mapper.Map<Room>(room);
            await _repository.CreateRoom(roomModel);

            var buildingReadDto = _mapper.Map<BuildingReadDto>(roomModel);
            return CreatedAtRoute(nameof(GetRoomById), new { Id = buildingReadDto.Id }, buildingReadDto);
        }
    }
}
