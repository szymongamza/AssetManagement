using AssetManagement.Application.Resources.Faculty;

namespace AssetManagement.Application.Resources.Building;
public class SaveBuildingResource
{
    public string Code { get; set; }
    public string City { get; set; }
    public string PostCode { get; set; }
    public string Street { get; set; }
    public ICollection<int> FacultiesIds { get; set; } = new List<int>();
}
