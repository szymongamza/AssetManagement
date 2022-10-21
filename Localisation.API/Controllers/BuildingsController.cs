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
        private readonly IBuildingRepo _repository;
        private readonly IMapper _mapper;

        public BuildingsController(IBuildingRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuildingReadDto>>> GetBuildings()
        {
            var buildings = await _repository.GetAllBuildings();
            return  Ok(_mapper.Map<IEnumerable<BuildingReadDto>>(buildings));
        }    
        
        [HttpGet("{id}", Name = "GetBuildingById")]
        public async Task<ActionResult<IEnumerable<BuildingReadDto>>> GetBuildingById(int id)
        {
            var building = await _repository.GetBuildingById(id);
            if(building != null)
                return  Ok(_mapper.Map<BuildingReadDto>(building));
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> CreateBuilding(BuildingCreateDtos building)
        {
            var buildingModel = _mapper.Map<Building>(building);
            await _repository.CreateBuilding(buildingModel);

            var buildingReadDto = _mapper.Map<BuildingReadDto>(buildingModel);
            return CreatedAtRoute(nameof(GetBuildingById), new {Id = buildingReadDto.Id}, buildingReadDto);
        }
    }
}
