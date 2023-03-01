
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Api.Dtos;

public class FacultyCreateDto
{
    public string FacultyCode { get; set; } = null!;
    public string FacultyName { get; set; } = null!;
}