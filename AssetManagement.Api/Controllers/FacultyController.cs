using AssetManagement.Api.Dtos;
using AssetManagement.Application.Interfaces;
using AssetManagement.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Api.Controllers;

public class FacultyController : BaseApiController
{
    private readonly IGenericRepository<Faculty> _facultyRepository;
    private readonly IMapper _mapper;

    public FacultyController(IGenericRepository<Faculty> facultyRepository, IMapper mapper)
    {
        _facultyRepository = facultyRepository;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateFaculty(FacultyCreateDto facultyDto)
    {
        var faculty = _mapper.Map<FacultyCreateDto, Faculty>(facultyDto);
        await _facultyRepository.AddAsync(faculty);
        return Ok(faculty.Id);
    }   
    
    [HttpGet]
    public async Task<IActionResult> GetFacultyById(int id)
    {
        var faculty = _facultyRepository.GetByIdAsync(id);
        return Ok(faculty);
    }
}