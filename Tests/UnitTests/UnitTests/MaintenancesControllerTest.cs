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
                cfg.AddProfile(new RoomsProfile());
            });
            _mapper = _config.CreateMapper();
            _controller = new MaintenancesController(_maintenanceRepo, _mapper);
        }
    }
}