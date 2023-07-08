using AssetManagement.Application.Resources.Faculty;

namespace AssetManagement.Application.Resources.Building;
public class BuildingResource
{
    public int Id { get; set; }
    public DateTime CreatedUtc { get; set; }
    public DateTime LastModifiedUtc { get; set; }
    public string Code { get; set; }
    public string City { get; set; }
    public string PostCode { get; set; }
    public string Street { get; set; }
    public ICollection<FacultyResource> Faculties { get; set; } = new List<FacultyResource>();
}
