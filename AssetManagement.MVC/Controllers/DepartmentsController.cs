using AssetManagement.Application.Interfaces;
using AssetManagement.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.MVC.Controllers;
public class DepartmentsController : Controller
{
    private readonly IGenericRepository<Department> _departmentRepository;
    // GET: DepartmentsController
    public DepartmentsController(IGenericRepository<Department> departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _departmentRepository.GetAllAsync());
    }

    // GET: DepartmentsController/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var department = await _departmentRepository.GetByIdAsync(id);
        if (department is null)
        {
            return NotFound();
        }
        return View(department);
    }

    // GET: DepartmentsController/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: DepartmentsController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("DepartmentCode,DepartmentName")]Department department)
    {
        if (ModelState.IsValid)
        {
            await _departmentRepository.AddAsync(department);
            return RedirectToAction(nameof(Index));
        }
        return View(department);
    }

    // GET: DepartmentsController/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var department = await _departmentRepository.GetByIdAsync(id);
        if (department is null)
        {
            return NotFound();
        }
        return View(department);
    }

    // POST: DepartmentsController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,[Bind("DepartmentCode,DepartmentName")] Department department)
    {
        if(id != department.Id)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            await _departmentRepository.UpdateAsync(department);
            return RedirectToAction(nameof(Index));
        }
        return View(department);
    }

    // GET: DepartmentsController/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var department = await _departmentRepository.GetByIdAsync(id);
        if (department is null)
        {
            return NotFound();
        }
        return View(department);
    }

    // POST: DepartmentsController/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var department = await _departmentRepository.GetByIdAsync(id);
        if (department is not null)
        {
            await _departmentRepository.DeleteAsync(department);
        }
        return RedirectToAction(nameof(Index));
    }
}

