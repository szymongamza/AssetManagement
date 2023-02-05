

namespace AssetManagement.Domain.Entities
{
    public class Faculty
    {
        public int Id { get; set; }
        public string FacultyCode { get; set; } = null!;
        public string FacultyName { get; set; } = null!;
        public IEnumerable<Building>? Buildings { get; set; }
        public IEnumerable<Department>? Departments { get; set; }
    }
}
