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
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetFacultyById(int id)
    {
        var faculty = await _facultyRepository.GetByIdAsync(id);
        return Ok(faculty);
    }   

    [HttpGet]
    public async Task<IActionResult> GetAllFaculties()
    {
        var faculties = await _facultyRepository.GetAllAsync();
        return Ok(faculties);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFaculties([FromQuery]int pageNumber, int pageSize)
    {
        var faculties = await _facultyRepository.GetPagedResponseAsync(pageNumber, pageSize);
        return Ok(faculties);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Faculty faculty)
    {
        if (id != faculty.Id)
        {
            return BadRequest();
        }

        await _facultyRepository.UpdateAsync(faculty);

        return NoContent();
    }   
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, Faculty faculty)
    {
        if (id != faculty.Id)
        {
            return BadRequest();
        }

        await _facultyRepository.UpdateAsync(faculty);

        return NoContent();
    }

}