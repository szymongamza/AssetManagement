using AssetManagement.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.MVC.Controllers;
public class AssetController : Controller
{
    private readonly IAssetRepository _assetRepository;
    private readonly IRoomRepository _roomRepository;
    private readonly IBuildingRepository _buildingRepository;
    // GET: AssetController
    public AssetController(IAssetRepository assetRepository, IRoomRepository roomRepository, IBuildingRepository buildingRepository)
    {
        _assetRepository = assetRepository;
        _roomRepository = roomRepository;
        _buildingRepository = buildingRepository;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _assetRepository.GetAllAsync());
    }

    // GET: AssetController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: AssetController/Create
    public ActionResult Create()
    {
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
