using AssetManagement.Application.Dtos;
using AssetManagement.Application.Interfaces;
using AssetManagement.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.MVC.Controllers;
public class DepartmentsController : Controller
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IFacultyRepository _facultyRepository;
    private readonly IMapper _mapper;
    // GET: DepartmentsController
    public DepartmentsController(IDepartmentRepository departmentRepository, IFacultyRepository facultyRepository, IMapper mapper)
    {
        _departmentRepository = departmentRepository;
        _facultyRepository = facultyRepository;
        _mapper = mapper;
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
    public async Task<IActionResult> Create()
    {
        ViewData["FacultyId"] = new SelectList(await _facultyRepository.GetAllAsync(), "Id", "Name");
        return View();
    }

    // POST: DepartmentsController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Code,Name,FacultyId")]DepartmentCreateDto departmentCreateDto)
    {
        if (ModelState.IsValid)
        {
			var faculty = await _facultyRepository.GetByIdAsync(departmentCreateDto.FacultyId);
			if (faculty is not null)
			{
                var department = _mapper.Map<DepartmentCreateDto, Department>(departmentCreateDto);
                department.Faculty = faculty;
				await _departmentRepository.AddAsync(department);
				return RedirectToAction(nameof(Index));
			}
		}

        ViewData["FacultyId"] = new SelectList(await _facultyRepository.GetAllAsync(), "Id", "Name");
        return View(_mapper.Map<DepartmentCreateDto, Department>(departmentCreateDto));
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
    public async Task<IActionResult> Edit(int id,[Bind("Id,Code,Name")] Department department)
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

