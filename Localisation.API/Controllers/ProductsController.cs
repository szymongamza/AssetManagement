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
        private readonly IMapper _mapper;

        public ProductsController(IProductRepo productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetProducts()
        {
            var products = await _productRepo.GetAllProducts();
            return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(products));
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetProductById(int id)
        {
            var product = await _productRepo.GetProductById(id);
            if (product != null)
                return Ok(_mapper.Map<ProductReadDto>(product));
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(ProductCreateDto product)
        {
            var productModel = _mapper.Map<Product>(product);
            await _productRepo.CreateProduct(productModel);

            var productReadDto = _mapper.Map<ProductReadDto>(productModel);
            return CreatedAtRoute(nameof(GetProductById), new { Id = productReadDto.Id }, productReadDto);
        }
    }
}
