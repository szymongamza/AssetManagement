using System.ComponentModel.DataAnnotations;

namespace AssetManagementAPI.Model
{
    public class Maintenance
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string? Description { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
