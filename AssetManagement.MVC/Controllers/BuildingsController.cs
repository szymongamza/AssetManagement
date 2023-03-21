using AssetManagement.Application.Interfaces;
using AssetManagement.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AssetManagement.MVC.Controllers;
public class BuildingsController : Controller
{
    private readonly IBuildingRepository _buildingRepository;
    private readonly IFacultyRepository _facultyRepository;
    private readonly IRoomRepository _roomRepository;
    // GET: BuildingsController
    public BuildingsController(IRoomRepository roomRepository, IFacultyRepository facultyRepository, IBuildingRepository buildingRepository)
    {
        _roomRepository = roomRepository;
        _facultyRepository = facultyRepository;
        _buildingRepository = buildingRepository;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _buildingRepository.GetAllAsync());
    }

    // GET: BuildingsController/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var building = await _buildingRepository.GetByIdAsync(id);
        if (building is null)
        {
            return NotFound();
        }
        return View(building);
    }

    // GET: BuildingsController/Create
    public async Task<IActionResult> Create()
    {
        ViewData["FacultyId"] = new MultiSelectList(await _facultyRepository.GetAllAsync(), "Id", "Name");
        ViewData["RoomId"] = new MultiSelectList(await _roomRepository.GetAllAsync(), "Id", "Name");
        return View();
    }

    // POST: BuildingsController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
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

    // GET: BuildingsController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: BuildingsController/Edit/5
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

    // GET: BuildingsController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: BuildingsController/Delete/5
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
