using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Core.Entities
{
    public class Maintenance : BaseEntity
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string? Description { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
