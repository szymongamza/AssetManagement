

namespace AssetManagement.Domain.Entities
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public IEnumerable<Asset>? Assets { get; set; }
    }
}
