using AssetManagement.Domain.Common;
using AssetManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AssetManagement.MVC.Models;

public class BuildingViewModel
{
    public int? Id { get; set; }
    public string? Code { get; set; } = null!;
    public string? City { get; set; }
    public string? PostCode { get; set; }
    public string? Street { get; set; }
    public List<string> SelectedFaculties { get; set; } = new List<string>();
}