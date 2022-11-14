using AutoMapper;
using Localisation.API.Controllers;
using Localisation.API.Dtos;
using Localisation.API.Model;
using Localisation.API.Profiles;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTests
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
            });
            _mapper = _config.CreateMapper();
            _controller = new BuildingsController(_buildingRepo,_roomRepo, _mapper);
        }


        [Fact]
        public async void Get_WhenCalled_ReturnsOkResult()
        {
            var okResult = await _controller.GetBuildings();
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }


        [Fact]
        public async void Get_WhenCalled_ReturnsAllBuildings()
        {
            var okResult = await _controller.GetBuildings() as OkObjectResult;

            var buildings = Assert.IsAssignableFrom<IEnumerable<BuildingReadDto>>(okResult.Value);

            Assert.Equal(3, buildings.Count());
        }
    }
}