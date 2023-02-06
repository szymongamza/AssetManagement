
using AssetManagement.Domain.Contracts;

namespace AssetManagement.Domain.Entities
{
    public class Building : Entity<int>
    {
        public string BuildingName { get; set; } = null!;
        public string? PostCode { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public int StreetNumber { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get;set; } = null!;
        public IEnumerable<Room>? Rooms { get; set; }
    }
}
