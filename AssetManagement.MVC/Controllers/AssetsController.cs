using AssetManagement.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AssetManagement.MVC.Controllers;
public class AssetsController : Controller
{
    private readonly IAssetRepository _assetRepository;
    private readonly IRoomRepository _roomRepository;
    private readonly IBuildingRepository _buildingRepository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IFacultyRepository _facultyRepository;
    // GET: AssetController
    public AssetsController(IAssetRepository assetRepository, IRoomRepository roomRepository, IBuildingRepository buildingRepository, IDepartmentRepository departmentRepository, IFacultyRepository facultyRepository)
    {
        _assetRepository = assetRepository;
        _roomRepository = roomRepository;
        _buildingRepository = buildingRepository;
        _departmentRepository = departmentRepository;
        _facultyRepository = facultyRepository;
    }

    public async Task<IActionResult> Index()
    {
        var assets = await _assetRepository.GetAllAsync();
        return View(assets);
    }

    // GET: AssetController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: AssetController/Create
    public async Task<IActionResult> Create()
    {
        ViewData["FacultyId"] = new SelectList(await _roomRepository.GetAllAsync(), "Id", "Name");
        ViewData["DepartmentId"] = new SelectList(await _roomRepository.GetAllAsync(), "Id", "Name");
        ViewData["RoomId"] = new SelectList(await _roomRepository.GetAllAsync(), "Id", "Code");
        ViewData["BuildingId"] = new SelectList(await _buildingRepository.GetAllAsync(), "Id", "Code");
        return View();
    }

    // POST: AssetController/Create
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

    // GET: AssetController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: AssetController/Edit/5
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

    // GET: AssetController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: AssetController/Delete/5
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
