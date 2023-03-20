
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Application.Dtos;

public class FacultyCreateDto
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
}