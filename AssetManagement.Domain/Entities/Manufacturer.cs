

using AssetManagement.Domain.Contracts;

namespace AssetManagement.Domain.Entities
{
    public class Manufacturer : Entity<int>
    {
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public IEnumerable<Asset>? Assets { get; set; }
    }
}
