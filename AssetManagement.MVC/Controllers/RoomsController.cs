using AssetManagement.Application.Interfaces;
using AssetManagement.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AssetManagement.MVC.Controllers;
public class RoomsController : Controller
{
    private readonly IRoomRepository _roomRepository;

    private readonly IBuildingRepository _buildingRepository;
    // GET: RoomsController
    public RoomsController(IRoomRepository roomRepository, IBuildingRepository buildingRepository)
    {
        _roomRepository = roomRepository;
        _buildingRepository = buildingRepository;
    }

    public async Task<IActionResult> Index()
    {
        var buildings = await _buildingRepository.GetAllAsync();
        return View(await _roomRepository.GetAllAsync());
    }

    // GET: RoomsController/Details/5
    public ActionResult Details(int id)
    {
        return View();
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

    // GET: RoomsController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
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
