


namespace AssetManagement.Domain.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = null!;
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; } = null!;
    }
}
