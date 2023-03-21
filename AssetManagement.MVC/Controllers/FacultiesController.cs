using AssetManagement.Application.Interfaces;
using AssetManagement.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.MVC.Controllers;
public class FacultiesController : Controller
{
    private readonly IFacultyRepository _facultyRepository;
    // GET: FacultiesController
    public FacultiesController(IFacultyRepository facultyRepository)
    {
        _facultyRepository = facultyRepository;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _facultyRepository.GetAllAsync());
    }

    // GET: FacultiesController/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var faculty = await _facultyRepository.GetByIdAsync(id);
        if (faculty is null)
        {
            return NotFound();
        }
        ViewData["Departments"] = await _facultyRepository.GetDepartmentsOfFaculty(id);
        return View(faculty);
    }

    // GET: FacultiesController/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: FacultiesController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Code,Name")]Faculty faculty)
    {
        if (ModelState.IsValid)
        {
            await _facultyRepository.AddAsync(faculty);
            return RedirectToAction(nameof(Index));
        }
        return View(faculty);
    }

    // GET: FacultiesController/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var faculty = await _facultyRepository.GetByIdAsync(id);
        if (faculty is null)
        {
            return NotFound();
        }
        return View(faculty);
    }

    // POST: FacultiesController/Edit/5
    [HttpPost, ActionName("Edit")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,[Bind("Id,Code,Name")] Faculty faculty)
    {
        if(id != faculty.Id)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            await _facultyRepository.UpdateAsync(faculty);
            return RedirectToAction(nameof(Index));
        }
        return View(faculty);
    }

    // GET: FacultiesController/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var faculty = await _facultyRepository.GetByIdAsync(id);
        if (faculty is null)
        {
            return NotFound();
        }
        return View(faculty);
    }

    // POST: FacultiesController/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var faculty = await _facultyRepository.GetByIdAsync(id);
        if (faculty is not null)
        {
            await _facultyRepository.DeleteAsync(faculty);
        }
        return RedirectToAction(nameof(Index));
    }
}

