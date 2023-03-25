using AssetManagement.Application.Interfaces;
using AssetManagement.Domain.Entities;
using AssetManagement.Infrastructure.Repositories;
using AssetManagement.MVC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AssetManagement.MVC.Controllers;
public class BuildingsController : Controller
{
    private readonly IBuildingRepository _buildingRepository;
    private readonly IFacultyRepository _facultyRepository;
    private readonly IMapper _mapper;
    // GET: BuildingsController
    public BuildingsController(IFacultyRepository facultyRepository, IBuildingRepository buildingRepository, IMapper mapper)
    {
        _facultyRepository = facultyRepository;
        _buildingRepository = buildingRepository;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _buildingRepository.GetAllBuildingsIncludeFaculties());
    }

    // GET: BuildingsController/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var building = await _buildingRepository.GetBuildingByIdIncludeFaculties(id);
        if (building is null)
        {
            return NotFound();
        }
        return View(building);
    }

    // GET: BuildingsController/Create
    public async Task<IActionResult> Create()
    {

        ViewData["Faculties"] = new MultiSelectList(await _facultyRepository.GetAllAsync(), "Id", "Name");
        return View();
    }

    // POST: BuildingsController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind]BuildingViewModel buildingView)
    {
        if (ModelState.IsValid)
        {
            var building = _mapper.Map<BuildingViewModel, Building>(buildingView);
            var listOfFaculties = new List<Faculty>();
            var faculties = await _facultyRepository.GetAllAsync();
            foreach (var selectedFaculty in buildingView.SelectedFaculties)
            {
                var faculty = faculties.FirstOrDefault(x=>x.Id == int.Parse(selectedFaculty));
                listOfFaculties.Add(faculty);
            }

            building.Faculties = listOfFaculties;
            await _buildingRepository.AddAsync(building);
            return RedirectToAction(nameof(Index));
        }

        return View(buildingView);

    }

    // GET: BuildingsController/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var building = await _buildingRepository.GetBuildingByIdIncludeFaculties(id);
        if (building is null)
        {
            return NotFound();
        }

        var faculties = await _facultyRepository.GetAllAsync();
        var buildingView = _mapper.Map<Building, BuildingViewModel>(building);
        buildingView.SelectedFaculties = ((List<int>)(building.Faculties.Select(x => x.Id).ToList())).ConvertAll<string>(x => x.ToString());
        ViewData["Faculties"] = new MultiSelectList(faculties, "Id", "Name",buildingView.SelectedFaculties);
        return View(buildingView);
    }

    // POST: BuildingsController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind] BuildingViewModel buildingView)
    {
        if (id != buildingView.Id)
        {
            return NotFound();
        }

        var building =await _buildingRepository.GetBuildingByIdIncludeFaculties(id);
        var faculties = await _facultyRepository.GetAllAsync();
        if (ModelState.IsValid)
        {
            _mapper.Map<BuildingViewModel, Building>(buildingView,building);
            var listOfFaculties = new List<Faculty>();

            foreach (var selectedFaculty in buildingView.SelectedFaculties)
            {
                var faculty = faculties.FirstOrDefault(x=> x.Id ==int.Parse(selectedFaculty));
                listOfFaculties.Add(faculty);
            }

            building.Faculties = listOfFaculties;
            await _buildingRepository.UpdateAsync(building);
            return RedirectToAction(nameof(Index));
        }
        buildingView.SelectedFaculties = ((List<int>)(building.Faculties.Select(x => x.Id).ToList())).ConvertAll<string>(x => x.ToString());
        ViewData["Faculties"] = new MultiSelectList(faculties, "Id", "Name", buildingView.SelectedFaculties);
        return View(buildingView);
    }

    // GET: BuildingsController/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var building = await _buildingRepository.GetBuildingByIdIncludeFaculties(id);
        if (building is null)
        {
            return NotFound();
        }
        return View(building);
    }

    // POST: BuildingsController/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var building = await _buildingRepository.GetByIdAsync(id);
        if (building is not null)
        {
            await _buildingRepository.DeleteAsync(building);
        }
        return RedirectToAction(nameof(Index));
    }
}
