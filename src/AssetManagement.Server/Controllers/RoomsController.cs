using AssetManagement.Server.Data.BuildingRepo;
using AssetManagement.Server.Data.ProductRepo;
using AssetManagement.Server.Data.RoomRepo;
using AssetManagement.Server.Dtos.ProductDtos;
using AssetManagement.Server.Dtos.RoomDtos;
using AssetManagement.Server.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomRepo _roomRepo;
        private readonly IBuildingRepo _buildingRepo;
        private readonly IProductRepo _productRepo;
        private readonly IMapper _mapper;

        public RoomsController(IRoomRepo roomRepo,IBuildingRepo buildingRepo,IProductRepo productRepo, IMapper mapper)
        {
            _roomRepo = roomRepo;
            _buildingRepo = buildingRepo;
            _productRepo = productRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetRooms()
        {
            var rooms = await _roomRepo.GetAllRooms();
            return Ok(_mapper.Map<IEnumerable<RoomReadDto>>(rooms));
        }

        [HttpGet("{id}", Name = "GetRoomById")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            var room = await _roomRepo.GetRoomById(id);
            if (room == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RoomReadDto>(room));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody]RoomCreateDto room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var building = await _buildingRepo.GetBuildingById(room.BuildingId);

            if (building == null)
            {
                return BadRequest("No such building");
            }

            if (!(room.Floor >= building.MinFloor && room.Floor <= building.MaxFloor))
            {
                return BadRequest("Floor out of range");
            }

            var roomModel = _mapper.Map<Room>(room);
            await _roomRepo.CreateRoom(roomModel);
            var roomReadDto = _mapper.Map<RoomReadDto>(roomModel);
            return CreatedAtAction(nameof(GetRoomById), new { Id = roomReadDto.Id }, roomReadDto);
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetProductsByRoomId(int id)
        {
            var room = await _roomRepo.GetRoomById(id);
            if (room == null)
            {
                return NotFound();
            }

            var products = await _productRepo.GetProductsByRoomId(id);
            return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(products));
        }
    }
}
