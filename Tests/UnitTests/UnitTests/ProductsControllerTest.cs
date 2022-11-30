using AutoMapper;
using Localisation.API.Controllers;
using Localisation.API.Dtos;
using Localisation.API.Model;
using Localisation.API.Profiles;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTests
{
    public class ProductsControllerTest
    {
        private readonly ProductRepoFake _productRepo;
        private readonly RoomRepoFake _roomRepo;
        private readonly MapperConfiguration _config;
        private readonly IMapper _mapper;
        private readonly ProductsController _controller;


        public ProductsControllerTest()
        {
            _productRepo = new ProductRepoFake();
            _roomRepo = new RoomRepoFake();
            _config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProductsProfile());
                cfg.AddProfile(new RoomsProfile());
            });
            _mapper = _config.CreateMapper();
            _controller = new ProductsController(_productRepo, _mapper);
        }

        // GET Methods
        [Fact]
        public async void GetProducts_WhenCalled_ReturnsOkResult()
        {
            var okResult = await _controller.GetProducts();
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }


        [Fact]
        public async void GetProducts_WhenCalled_ReturnsAllProducts()
        {
            var okResult = await _controller.GetProducts() as OkObjectResult;

            var products = Assert.IsAssignableFrom<IEnumerable<ProductReadDto>>(okResult?.Value);

            Assert.Equal(3, products.Count());
        }

        [Fact]
        public async void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            var notFoundResult = await _controller.GetProductById(-1);

            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public async void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            int id = 1;

            var okResult = await _controller.GetProductById(id);

            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public async void GetById_ExistingIdPassed_ReturnsRightProduct()
        {
            int id = 1;

            var okResult = await _controller.GetProductById(id) as OkObjectResult;

            Assert.IsType<ProductReadDto>(okResult?.Value);
            Assert.Equal(id, (okResult?.Value as ProductReadDto)?.Id);
        }

        //Post Method
        [Fact]
        public async void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            var nameMissingProduct = new ProductCreateDto()
            {
                Manufacturer = "ATMAT",
                AdditionalDescription = "3D Printer",
                DateTimeOfBuy = new DateTime(2022, 6, 12),
                DateTimeOfEndOfGuarantee = new DateTime(2023, 6, 12),
                DateTimeOfNextMaintainance = new DateTime(2022, 12, 12),
                ManufacturerSerialNumber = "2022/321534/34236",
                RoomId = 2
            };
            _controller.ModelState.AddModelError("Name", "Required");

            var badResponse = await _controller.CreateProduct(nameMissingProduct);

            Assert.IsType<BadRequestObjectResult>(badResponse as BadRequestObjectResult);
        }    
        
        [Fact]
        public async void Add_VaildObjectPassed_ReturnsCreatedRequest()
        {
            var productCreateDto = new ProductCreateDto()
            {
                Name = "Signal Pro 500",
                Manufacturer = "ATMAT",
                AdditionalDescription = "3D Printer",
                DateTimeOfBuy = new DateTime(2022, 6, 12),
                DateTimeOfEndOfGuarantee = new DateTime(2023, 6, 12),
                DateTimeOfNextMaintainance = new DateTime(2022, 12, 12),
                ManufacturerSerialNumber = "2022/321534/34237",
                RoomId = 3
            };

            var createdResponse = await _controller.CreateProduct(productCreateDto);

            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }      
        
        [Fact]
        public async void Add_VaildObjectPassed_ReturnedResponseHasCreatedProduct()
        {
            var productCreateDto = new ProductCreateDto()
            {
                Name = "Signal Pro 500",
                Manufacturer = "ATMAT",
                AdditionalDescription = "3D Printer",
                DateTimeOfBuy = new DateTime(2022, 6, 12),
                DateTimeOfEndOfGuarantee = new DateTime(2023, 6, 12),
                DateTimeOfNextMaintainance = new DateTime(2022, 12, 12),
                ManufacturerSerialNumber = "2022/321534/34237",
                RoomId = 3
            };

            var createdResponse = await _controller.CreateProduct(productCreateDto) as CreatedAtActionResult;
            var product = createdResponse?.Value as ProductReadDto;

            Assert.IsType<ProductReadDto>(product);
            Assert.Equal(productCreateDto.Name,product?.Name);
        }
    }
}