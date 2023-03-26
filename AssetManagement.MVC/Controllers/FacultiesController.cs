using AssetManagement.Application.Interfaces;
using AssetManagement.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.MVC.Controllers;
public class FacultiesController : Controller
{
    private readonly IFacultyRepository _facultyRepository;
    private readonly IDepartmentRepository _departmentRepository;
    // GET: FacultiesController
    public FacultiesController(IFacultyRepository facultyRepository, IDepartmentRepository departmentRepository)
    {
        _facultyRepository = facultyRepository;
        _departmentRepository = departmentRepository;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _facultyRepository.GetFacultiesIncludeBuildingsAndDepartments());
    }

    // GET: FacultiesController/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var faculty = await _facultyRepository.GetFacultyIncludeBuildingsAndDepartments(id);
        if (faculty is null)
        {
            return NotFound();
        }
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
            return BadRequest();
        }
        var orgFaculty = await _facultyRepository.GetByIdAsync(id);
        if (orgFaculty is null)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {

            orgFaculty.Code = faculty.Code;
            orgFaculty.Name = faculty.Name;
            await _facultyRepository.UpdateAsync(orgFaculty);
            return RedirectToAction(nameof(Index));
        }
        return View(faculty);
    }

    // GET: FacultiesController/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var faculty = await _facultyRepository.GetFacultyIncludeBuildingsAndDepartments(id);
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

