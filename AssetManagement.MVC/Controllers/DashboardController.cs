using System.Diagnostics;
using AssetManagement.Application.Interfaces;
using AssetManagement.Domain.Entities;
using AssetManagement.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.MVC.Controllers;
public class DashboardController : Controller
{
    private readonly IGenericRepository<Faculty> _facultyRepository;
    private readonly IGenericRepository<Department> _departmentRepository;
    public DashboardController(IGenericRepository<Faculty> facultyRepository, IGenericRepository<Department> departmentRepository)
    {
        _facultyRepository = facultyRepository;
        _departmentRepository = departmentRepository;
    }

    public async Task<IActionResult> Index()
    {
        var countOfFaculties = await _facultyRepository.GetCount();
        var countOfDepartments = await _departmentRepository.GetCount();
        ViewBag.CountOfFaculties = countOfFaculties;
        ViewBag.CountOfDepartments = countOfDepartments;
        return View();
    }

    public IActionResult Rights()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
