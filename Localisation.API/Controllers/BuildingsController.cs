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
    public class BuildingsController : ControllerBase
    {
        private readonly IBuildingRepo _buildingRepo;
        private readonly IRoomRepo _roomRepo;
        private readonly IMapper _mapper;

        public BuildingsController(IBuildingRepo buildingRepo,IRoomRepo roomRepo, IMapper mapper)
        {
            _buildingRepo = buildingRepo;
            _roomRepo = roomRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetBuildings()
        {
            var buildings = await _buildingRepo.GetAllBuildings();
            return  Ok(_mapper.Map<IEnumerable<BuildingReadDto>>(buildings));
        }    
        
        [HttpGet("{id}", Name = "GetBuildingById")]
        public async Task<IActionResult> GetBuildingById(int id)
        {
            var building = await _buildingRepo.GetBuildingById(id);
            if (building == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BuildingReadDto>(building));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBuilding([FromBody]BuildingCreateDto building)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var buildingModel = _mapper.Map<Building>(building);
            await _buildingRepo.CreateBuilding(buildingModel);

            var buildingReadDto = _mapper.Map<BuildingReadDto>(buildingModel);
            return CreatedAtAction(nameof(GetBuildingById), new {Id = buildingReadDto.Id}, buildingReadDto);
        }

        [HttpGet("{id}/rooms")]
        public async Task<IActionResult> GetRoomsByBuildingId(int id)
        {
            var building = await _buildingRepo.GetBuildingById(id);
            if (building == null)
            {
                return NotFound();
            }

            var rooms = await _roomRepo.GetRoomsByBuildingId(id);
            return Ok(_mapper.Map<IEnumerable<RoomReadDto>>(rooms));
        }
    }
}
