using AssetManagement.Application.Dtos;
using AssetManagement.Application.Interfaces;
using AssetManagement.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Api.Controllers;

public class DepartmentController : BaseApiController
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IMapper _mapper;

    public DepartmentController(IDepartmentRepository departmentRepository, IMapper mapper)
    {
        _departmentRepository = departmentRepository;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Department), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDepartmentById(int id)
    {
        var department = await _departmentRepository.GetByIdAsync(id);
        if (department is not Department)
        {
            return NotFound("Department not found");
        }

        return Ok(department);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Department>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDepartments()
    {
        var departments = await _departmentRepository.GetAllAsync();
        if (departments == null || departments.Count <= 0)
        {
            return NotFound("Departments not found");
        }
        return Ok(departments);
    }

    [HttpGet("paged")]
    [ProducesResponseType(typeof(List<Department>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPagedDepartments([FromQuery] int pageNumber, int pageSize)
    {
        var departments = await _departmentRepository.GetPagedResponseAsync(pageNumber, pageSize);
        if (departments == null || departments.Items.Count() <= 0)
        {
            return NotFound("Departments not found");
        }
        return Ok(departments);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateDepartment(DepartmentCreateDto departmentDto)
    {
        var department = _mapper.Map<DepartmentCreateDto, Department>(departmentDto);
        await _departmentRepository.AddAsync(department);

        return CreatedAtAction(nameof(GetDepartmentById), new { id = department.Id }, departmentDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Update(int id, Department department)
    {
        if (id != department.Id)
        {
            return BadRequest("id and department.id aren't equal");
        }
        if (await _departmentRepository.GetByIdAsync(id) is not Department)
        {
            return NotFound("Department not found");
        }

        await _departmentRepository.UpdateAsync(department);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(int id)
    {
        var department = await _departmentRepository.GetByIdAsync(id);
        if (department is not Department)
        {
            return NotFound("Department not found");
        }
        await _departmentRepository.DeleteAsync(department);
        return NoContent();
    }
}