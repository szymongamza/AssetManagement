using AssetManagement.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.MVC.Controllers;
public class RoomsController : Controller
{
    private readonly IRoomRepository _roomRepository;
    // GET: RoomsController
    public RoomsController(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _roomRepository.GetAllAsync());
    }

    // GET: RoomsController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: RoomsController/Create
    public ActionResult Create()
    {
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
