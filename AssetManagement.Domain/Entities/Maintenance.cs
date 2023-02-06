
using AssetManagement.Domain.Contracts;
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Domain.Entities
{
    public class Maintenance : Entity<int>
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string? Description { get; set; }
        public int AssetId { get; set; }
        public Asset Product { get; set; } = null!;
    }
}
