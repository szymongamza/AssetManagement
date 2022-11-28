using AutoMapper;
using Localisation.API.Controllers;
using Localisation.API.Dtos;
using Localisation.API.Profiles;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class RoomsControllerTest
    {
        private readonly RoomRepoFake _roomRepo;
        private readonly BuildingRepoFake _buildingRepo;
        private readonly MapperConfiguration _config;
        private readonly IMapper _mapper;
        private readonly RoomsController _controller;


        public RoomsControllerTest()
        {
            _roomRepo = new RoomRepoFake();
            _buildingRepo = new BuildingRepoFake();
            _config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new RoomsProfile());
            });
            _mapper = _config.CreateMapper();
            _controller = new RoomsController(_roomRepo, _buildingRepo, _mapper);
        }

        // GET Methods
        [Fact]
        public async void GetRooms_WhenCalled_ReturnsOkResult()
        {
            var okResult = await _controller.GetRooms();
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public async void GetRooms_WhenCalled_ReturnsAllRooms()
        {
            var okResult = await _controller.GetRooms() as OkObjectResult;

            var buildings = Assert.IsAssignableFrom<IEnumerable<RoomReadDto>>(okResult?.Value);

            Assert.Equal(4, buildings.Count());
        }

        [Fact]
        public async void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            var notFoundResult = await _controller.GetRoomById(-1);

            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public async void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            int id = 1;

            var okResult = await _controller.GetRoomById(id);

            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public async void GetById_ExistingIdPassed_ReturnsRightRoom()
        {
            int id = 1;

            var okResult = await _controller.GetRoomById(id) as OkObjectResult;

            Assert.IsType<RoomReadDto>(okResult?.Value);
            Assert.Equal(id, (okResult?.Value as RoomReadDto)?.Id);
        }

        //Post Method
        [Fact]
        public async void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            var nameMissingRoom = new RoomCreateDto()
            {
                Name = "B5",
                BuildingId = 5,
            };
            _controller.ModelState.AddModelError("Floor", "Required");

            var badResponse = await _controller.CreateRoom(nameMissingRoom);

            Assert.IsType<BadRequestObjectResult>(badResponse as BadRequestObjectResult);
        }
    }
}
