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

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Faculty), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetFacultyById(int id)
    {
        var faculty = await _facultyRepository.GetByIdAsync(id);
        if (faculty is not Faculty)
        {
            return NotFound("Faculty not found");
        }

        return Ok(faculty);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Faculty>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetFaculties()
    {
        var faculties = await _facultyRepository.GetAllAsync();
        if (faculties == null || faculties.Count <= 0)
        {
            return NotFound("Faculties not found");
        }
        return Ok(faculties);
    }

    [HttpGet("paged")]
    [ProducesResponseType(typeof(List<Faculty>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPagedFaculties([FromQuery] int pageNumber, int pageSize)
    {
        var faculties = await _facultyRepository.GetPagedResponseAsync(pageNumber, pageSize);
        if (faculties == null || !faculties.Items.Any())
        {
            return NotFound("Faculties not found");
        }
        return Ok(faculties);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateFaculty(FacultyCreateDto facultyDto)
    {
        var faculty = _mapper.Map<FacultyCreateDto, Faculty>(facultyDto);
        await _facultyRepository.AddAsync(faculty);

        return CreatedAtAction(nameof(GetFacultyById), new { id = faculty.Id }, facultyDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Update(int id, Faculty faculty)
    {
        if (id != faculty.Id)
        {
            return BadRequest("id and faculty.id aren't equal");
        }
        if (await _facultyRepository.GetByIdAsync(id) is not Faculty)
        {
            return NotFound("Faculty not found");
        }

        await _facultyRepository.UpdateAsync(faculty);
        return NoContent();
    }   

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(int id)
    {
        var faculty = await _facultyRepository.GetByIdAsync(id);
        if (faculty is not Faculty)
        {
            return NotFound("Faculty not found");
        }
        await _facultyRepository.DeleteAsync(faculty);
        return NoContent();
    }
}