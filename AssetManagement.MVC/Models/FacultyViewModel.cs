using Microsoft.AspNetCore.Mvc.Rendering;

namespace AssetManagement.MVC.Models;

public class FacultyViewModel
{
    public List<SelectListItem> Faculties { get; set; }
    public int[] FacultiesIds { get; set; }
}
