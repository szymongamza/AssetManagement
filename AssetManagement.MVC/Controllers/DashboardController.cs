using System.Diagnostics;
using AssetManagement.Application.Interfaces;
using AssetManagement.Domain.Entities;
using AssetManagement.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.MVC.Controllers;
public class DashboardController : Controller
{
    private readonly IFacultyRepository _facultyRepository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IBuildingRepository _buildingRepository;
    public DashboardController(IFacultyRepository facultyRepository, IDepartmentRepository departmentRepository, IBuildingRepository buildingRepository)
    {
        _facultyRepository = facultyRepository;
        _departmentRepository = departmentRepository;
        _buildingRepository = buildingRepository;
    }

    public async Task<IActionResult> Index()
    {
        var countOfFaculties = await _facultyRepository.GetCount();
        var countOfDepartments = await _departmentRepository.GetCount();
        var countOfBuildings = await _buildingRepository.GetCount();
        ViewBag.CountOfFaculties = countOfFaculties;
        ViewBag.CountOfDepartments = countOfDepartments;
        ViewBag.CountOfBuildings = countOfBuildings;
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
