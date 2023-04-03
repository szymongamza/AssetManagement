using AssetManagement.Application.Dtos;
using AssetManagement.Application.Interfaces;
using AssetManagement.Domain.Entities;
using AssetManagement.Infrastructure.Repositories;
using AssetManagement.MVC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AssetManagement.MVC.Controllers;
public class RoomsController : Controller
{
    private readonly IRoomRepository _roomRepository;

    private readonly IBuildingRepository _buildingRepository;

    private readonly IMapper _mapper;
    // GET: RoomsController
    public RoomsController(IRoomRepository roomRepository, IBuildingRepository buildingRepository, IMapper mapper)
    {
        _roomRepository = roomRepository;
        _buildingRepository = buildingRepository;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var buildings = await _buildingRepository.GetAllAsync();
        return View(await _roomRepository.GetAllAsync());
    }

    // GET: RoomsController/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var room = await _roomRepository.GetByIdAsync(id);
        if(room is null)
        {
            return BadRequest();
        }
        var building = await _buildingRepository.GetByIdAsync(room.BuildingId);
        return View(room);
    }

    // GET: RoomsController/Create
    public async Task<IActionResult> Create()
    {
        ViewData["BuildingId"] = new SelectList(await _buildingRepository.GetAllAsync(), "Id", "Code");
        return View();
    }

    // POST: RoomsController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind] RoomViewModel roomViewModel)
    {
        if (ModelState.IsValid)
        {
            var building = await _buildingRepository.GetByIdAsync(roomViewModel.BuildingId);
            if (building is not null)
            {
                var room = _mapper.Map<RoomViewModel, Room>(roomViewModel);
                room.Building = building;
                await _roomRepository.AddAsync(room);
                return RedirectToAction(nameof(Index));
            }
        }

        ViewData["BuildingId"] = new SelectList(await _buildingRepository.GetAllAsync(), "Id", "Code");
        return View(roomViewModel);
    }

    // GET: RoomsController/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var room = await _roomRepository.GetByIdAsync(id);
        if (room is null)
        {
            return NotFound();
        }

        var buildings = await _buildingRepository.GetAllAsync();
        var selectedBuilding = buildings.FirstOrDefault(x => x.Id == room.BuildingId);
        ViewData["BuildingId"] = new SelectList(buildings, "Id", "Code", selectedBuilding);
        return View(_mapper.Map<Room, RoomViewModel>(room));
    }

    // POST: RoomsController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: RoomsController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: RoomsController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
