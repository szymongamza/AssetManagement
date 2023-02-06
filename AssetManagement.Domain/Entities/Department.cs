
using AssetManagement.Domain.Contracts;

namespace AssetManagement.Domain.Entities
{
    public class Department : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; } = null!;
    }
}
