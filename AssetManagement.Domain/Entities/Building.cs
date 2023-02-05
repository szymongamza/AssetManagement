
namespace AssetManagement.Domain.Entities
{
    public class Building
    {
        public int Id { get; set; }
        public string BuildingName { get; set; } = null!;
        public Address? Address { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get;set; } = null!;
        public IEnumerable<Room>? Rooms { get; set; }
    }
}
