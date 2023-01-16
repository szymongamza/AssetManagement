using System.Collections.Generic;
using System.Linq;
using AssetManagementAPI.Controllers;
using AssetManagementAPI.Dtos;
using AssetManagementAPI.Profiles;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AssetManagementAPI.Tests
{
    public class BuildingsControllerTest
    {
        private readonly BuildingRepoFake _buildingRepo;
        private readonly RoomRepoFake _roomRepo;
        private readonly MapperConfiguration _config;
        private readonly IMapper _mapper;
        private readonly BuildingsController _controller;


        public BuildingsControllerTest()
        {
            _buildingRepo = new BuildingRepoFake();
            _roomRepo = new RoomRepoFake();
            _config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new BuildingsProfile());
                cfg.AddProfile(new RoomsProfile());
            });
            _mapper = _config.CreateMapper();
            _controller = new BuildingsController(_buildingRepo,_roomRepo, _mapper);
        }

        // GET Methods
        [Fact]
        public async void GetBuildings_WhenCalled_ReturnsOkResult()
        {
            var okResult = await _controller.GetBuildings();
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }


        [Fact]
        public async void GetBuildings_WhenCalled_ReturnsAllBuildings()
        {
            var okResult = await _controller.GetBuildings() as OkObjectResult;

            var buildings = Assert.IsAssignableFrom<IEnumerable<BuildingReadDto>>(okResult?.Value);

            Assert.Equal(3, buildings.Count());
        }

        [Fact]
        public async void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            var notFoundResult = await _controller.GetBuildingById(-1);

            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public async void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            int id = 1;

            var okResult = await _controller.GetBuildingById(id);

            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public async void GetById_ExistingIdPassed_ReturnsRightBuilding()
        {
            int id = 1;

            var okResult = await _controller.GetBuildingById(id) as OkObjectResult;

            Assert.IsType<BuildingReadDto>(okResult?.Value);
            Assert.Equal(id, (okResult?.Value as BuildingReadDto)?.Id);
        }

        //Post Method
        [Fact]
        public async void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            var nameMissingRoom = new BuildingCreateDto()
            {
                BuildingCode = "B5",
                MaxFloor = 5,
                MinFloor = -1
            };
            _controller.ModelState.AddModelError("Name", "Required");

            var badResponse = await _controller.CreateBuilding(nameMissingRoom);

            Assert.IsType<BadRequestObjectResult>(badResponse as BadRequestObjectResult);
        }    
        
        [Fact]
        public async void Add_VaildObjectPassed_ReturnsCreatedRequest()
        {
            var buildingCreateDto = new BuildingCreateDto()
            {
                Name = "Test",
                BuildingCode = "test",
                MaxFloor = 5,
                MinFloor = -1
            };

            var createdResponse = await _controller.CreateBuilding(buildingCreateDto);

            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }      
        
        [Fact]
        public async void Add_VaildObjectPassed_ReturnedResponseHasCreatedBuilding()
        {
            var buildingCreateDto = new BuildingCreateDto()
            {   
                Name = "Test",
                BuildingCode = "test",
                MaxFloor = 5,
                MinFloor = -1
            };

            var createdResponse = await _controller.CreateBuilding(buildingCreateDto) as CreatedAtActionResult;
            var building = createdResponse?.Value as BuildingReadDto;

            Assert.IsType<BuildingReadDto>(building);
            Assert.Equal(buildingCreateDto.Name,building?.Name);
        }



        [Fact]
        public async void GetRoomsByBuildingId_UnknownIdPassed_ReturnsNotFoundResult()
        {
            int id = -1;

            var notFoundResult = await _controller.GetRoomsByBuildingId(id);

            Assert.IsType<NotFoundResult>(notFoundResult);
        }      
        
        [Fact]
        public async void GetRoomsByBuildingId_ExistingIdPassed_ReturnsOkResult()
        {
            int id = 1;

            var okResult = await _controller.GetRoomsByBuildingId(id);

            Assert.IsType<OkObjectResult>(okResult);
        }     
        
        [Fact]
        public async void GetRoomsByBuildingId_ExistingIdPassed_ReturnsRooms()
        {
            int id = 1;

            var okResult = await _controller.GetRoomsByBuildingId(id) as OkObjectResult;

            var rooms = Assert.IsAssignableFrom<IEnumerable<RoomReadDto>>(okResult?.Value);
            Assert.Equal(2, rooms.Count());
        }
    }
}