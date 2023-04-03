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
    private readonly IRoomRepository _roomRepository;
    public DashboardController(IRoomRepository roomRepository, IDepartmentRepository departmentRepository, IFacultyRepository facultyRepository, IBuildingRepository buildingRepository)
    {
        _roomRepository = roomRepository;
        _departmentRepository = departmentRepository;
        _facultyRepository = facultyRepository;
        _buildingRepository = buildingRepository;
    }

    public async Task<IActionResult> Index()
    {
        var countOfFaculties = await _facultyRepository.GetCount();
        var countOfDepartments = await _departmentRepository.GetCount();
        var countOfBuildings = await _buildingRepository.GetCount();
        var countOfRooms = await _roomRepository.GetCount();
        ViewBag.CountOfFaculties = countOfFaculties;
        ViewBag.CountOfDepartments = countOfDepartments;
        ViewBag.CountOfBuildings = countOfBuildings;
        ViewBag.CountOfRooms = countOfRooms;

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
