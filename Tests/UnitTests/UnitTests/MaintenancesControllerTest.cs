using AutoMapper;
using Localisation.API.Controllers;
using Localisation.API.Dtos;
using Localisation.API.Model;
using Localisation.API.Profiles;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTests
{
    public class MaintenancesControllerTest
    {
        private readonly MaintenanceRepoFake _maintenanceRepo;
        private readonly MapperConfiguration _config;
        private readonly IMapper _mapper;
        private readonly MaintenancesController _controller;


        public MaintenancesControllerTest()
        {
            _maintenanceRepo = new MaintenanceRepoFake();
            _config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MaintenancesProfile());
            });
            _mapper = _config.CreateMapper();
            _controller = new MaintenancesController(_maintenanceRepo, _mapper);
        }
        [Fact]
        public async void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            int id = -1;
            var notFoundResult = await _controller.GetMaintenanceById(id);
            Assert.IsType<NotFoundResult>(notFoundResult);
        }
        [Fact]
        public async void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            int id = 1;
            var okResult = await _controller.GetMaintenanceById(id);
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        [Fact]
        public async void GetById_ExistingIdPassed_ReturnsRightMaintenance()
        {
            int id = 1;
            var okResult = await _controller.GetMaintenanceById(id) as OkObjectResult;

            Assert.IsType<MaintenanceReadDto>(okResult?.Value);
            Assert.Equal(id, (okResult?.Value as MaintenanceReadDto)?.Id);
        }

        //Post Method
        [Fact]
        public async void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            var nameMissingMaintenance = new MaintenanceCreateDto()
            {
                DateStart = DateTime.Parse("2022-06-28"),
                DateEnd = DateTime.Parse("2022-06-30"),
                Description = "Changed nozzle"
            };
            _controller.ModelState.AddModelError("ProductId", "Required");

            var badResponse = await _controller.CreateMaintenance(nameMissingMaintenance);

            Assert.IsType<BadRequestObjectResult>(badResponse as BadRequestObjectResult);
        }

        [Fact]
        public async void Add_VaildObjectPassed_ReturnsCreatedRequest()
        {
            var maintenanceCreateDto = new MaintenanceCreateDto()
            {
                DateStart = DateTime.Parse("2022-06-28"),
                DateEnd = DateTime.Parse("2022-06-30"),
                Description = "Changed nozzle",
                ProductId = 1
            };

            var createdResponse = await _controller.CreateMaintenance(maintenanceCreateDto);

            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }

        [Fact]
        public async void Add_VaildObjectPassed_ReturnedResponseHasCreatedMaintenance()
        {
            var maintenanceCreateDto = new MaintenanceCreateDto()
            {
                DateStart = DateTime.Parse("2022-06-28"),
                DateEnd = DateTime.Parse("2022-06-30"),
                Description = "Changed nozzle",
                ProductId = 1
            };

            var createdResponse = await _controller.CreateMaintenance(maintenanceCreateDto) as CreatedAtActionResult;
            var maintenance = createdResponse?.Value as MaintenanceReadDto;

            Assert.IsType<MaintenanceReadDto>(maintenance);
            Assert.Equal(maintenanceCreateDto.Description, maintenance?.Description);
        }
    }
}