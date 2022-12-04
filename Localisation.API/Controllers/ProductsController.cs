using AutoMapper;
using Localisation.API.Data;
using Localisation.API.Dtos;
using Localisation.API.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Localisation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _productRepo;
        private readonly IMaintenanceRepo _maintenanceRepo;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepo productRepo,IMaintenanceRepo maintenanceRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _maintenanceRepo = maintenanceRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productRepo.GetAllProducts();
            return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(products));
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productRepo.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProductReadDto>(product));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody]ProductCreateDto product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productModel = _mapper.Map<Product>(product);
            await _productRepo.CreateProduct(productModel);

            var productReadDto = _mapper.Map<ProductReadDto>(productModel);
            return CreatedAtAction(nameof(GetProductById), new { Id = productReadDto.Id }, productReadDto);
        }

        [HttpGet("{id}/maintenances")]
        public async Task<IActionResult> GetMaintenancesByProductId(int id)
        {
            var product = await _productRepo.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            var maintenances = await _maintenanceRepo.GetMaintenancesOfProduct(id);
            return Ok(_mapper.Map<IEnumerable<MaintenanceReadDto>>(maintenances));
        }       
        
        [HttpGet("{id}/maintenances/last")]
        public async Task<IActionResult> GetLastMaintenanceByProductId(int id)
        {
            var product = await _productRepo.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            var maintenance = await _maintenanceRepo.GetLastMaintenanceOfProduct(id);
            return Ok(_mapper.Map<MaintenanceReadDto>(maintenance));
        }
    }
}
