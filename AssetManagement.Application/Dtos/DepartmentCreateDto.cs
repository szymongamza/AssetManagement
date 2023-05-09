using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Dtos;

public class DepartmentCreateDto
{
    public int? Id { get; set; }
    public string? Code {get;set;}
    public string Name { get; set; } = null!;
    public int FacultyId { get; set; }
}