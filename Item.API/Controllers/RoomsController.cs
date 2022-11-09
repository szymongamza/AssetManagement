using AutoMapper;
using Item.API.Data;
using Item.API.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Item.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IProductRepo _repository;
        private readonly IMapper _mapper;

        public RoomsController(IProductRepo productRepo, IMapper mapper)
        {
            _repository = productRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomReadDto>>> GetRooms()
        {
            var rooms = await _repository.GetAllRooms();

            return Ok(_mapper.Map<IEnumerable<RoomReadDto>>(rooms));
        }


    }
}
