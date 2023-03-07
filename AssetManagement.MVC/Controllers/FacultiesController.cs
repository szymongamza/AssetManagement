using AssetManagement.Application.Interfaces;
using AssetManagement.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.MVC.Controllers;
public class FacultiesController : Controller
{
    private readonly IGenericRepository<Faculty> _facultyRepository;
    // GET: FacultiesController
    public FacultiesController(IGenericRepository<Faculty> facultyRepository)
    {
        _facultyRepository = facultyRepository;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _facultyRepository.GetAllAsync());
    }

    // GET: FacultiesController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: FacultiesController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: FacultiesController/Create
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

    // GET: FacultiesController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: FacultiesController/Edit/5
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

    // GET: FacultiesController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: FacultiesController/Delete/5
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
