using AutoMapper;
using AssetManagementAPI.Data;
using AssetManagementAPI.Dtos;
using AssetManagementAPI.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenancesController : ControllerBase
    {
        private readonly IMaintenanceRepo _maintenanceRepo;
        private readonly IMapper _mapper;

        public MaintenancesController(IMaintenanceRepo maintenanceRepo, IMapper mapper)
        {
            _maintenanceRepo = maintenanceRepo;
            _mapper = mapper;
        }

        [HttpGet("{productId}", Name = "GetMaintenancesOfProduct")]
        public async Task<IActionResult> GetMaintenancesOfProduct(int productId)
        {
            var maintenances = await _maintenanceRepo.GetMaintenancesOfProduct(productId);
            return Ok(_mapper.Map<IEnumerable<MaintenanceReadDto>>(maintenances));
        }

        [HttpGet("{id}", Name = "GetMaintenanceById")]
        public async Task<IActionResult> GetMaintenanceById(int id)
        {
            var maintenance = await _maintenanceRepo.GetMaintenanceById(id);
            if (maintenance == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<MaintenanceReadDto>(maintenance));
        }

        [HttpGet("/Product/{productId}", Name = "GetLastMaintenanceOfProduct")]
        public async Task<IActionResult> GetLastMaintenanceOfProduct(int productId)
        {
            var maintenance = await _maintenanceRepo.GetLastMaintenanceOfProduct(productId);
            if (maintenance == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<MaintenanceReadDto>(maintenance));
        }


        [HttpPost]
        public async Task<IActionResult> CreateMaintenance([FromBody]MaintenanceCreateDto maintenance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var maintenanceModel = _mapper.Map<Maintenance>(maintenance);
            await _maintenanceRepo.CreateMaintenance(maintenanceModel);

            var maintenanceReadDto = _mapper.Map<MaintenanceReadDto>(maintenanceModel);
            return CreatedAtAction(nameof(GetMaintenanceById), new { Id = maintenanceReadDto.Id }, maintenanceReadDto);
        }
    }
}
