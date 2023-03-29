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
        var faculties =await _facultyRepository.GetAllAsync();
        var departments =await _departmentRepository.GetAllAsync();
        return View(departments);
    }

    // GET: DepartmentsController/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var department = await _departmentRepository.GetByIdAsync(id);
        if (department is null)
        {
            return NotFound();
        }
        var facultyOfDepartment = await _facultyRepository.GetByIdAsync(department.FacultyId);
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
    public async Task<IActionResult> Create([Bind]DepartmentCreateDto departmentCreateDto)
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

        var faculties = await _facultyRepository.GetAllAsync();
        var selectedFaculty = faculties.FirstOrDefault(x => x.Id == department.FacultyId);
        ViewData["FacultyId"] = new SelectList(faculties, "Id", "Name",selectedFaculty);
        return View(_mapper.Map<Department, DepartmentCreateDto>(department));
    }

    // POST: DepartmentsController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,[Bind] DepartmentCreateDto departmentCreateDto)
    {
        if(id != departmentCreateDto.Id)
        {
            return BadRequest();
        }

        var department = await _departmentRepository.GetDepartmentByIdIncludeFaculty(id);
        if (department is null)
        {
            return NotFound();
        }

        var faculties = await _facultyRepository.GetAllAsync();
        if (ModelState.IsValid)
        {
            department = _mapper.Map<DepartmentCreateDto, Department>(departmentCreateDto);
            department.Faculty = faculties.FirstOrDefault(x => x.Id == department.FacultyId);
            await _departmentRepository.UpdateAsync(department);
            return RedirectToAction(nameof(Index));
        }
        ViewData["FacultyId"] = new SelectList(faculties, "Id", "Name", faculties.FirstOrDefault(x => x.Id == departmentCreateDto.FacultyId));
        return View(departmentCreateDto);
    }

    // GET: DepartmentsController/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var department = await _departmentRepository.GetByIdAsync(id);
        if (department is null)
        {
            return NotFound();
        }
        var facultyOfDepartment = await _facultyRepository.GetByIdAsync(department.FacultyId);

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

