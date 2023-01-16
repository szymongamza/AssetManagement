using System.ComponentModel.DataAnnotations;

namespace AssetManagementAPI.Model
{
    public class Room
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Floor { get; set; }
        [Required]
        public int BuildingId { get; set; }
        public Building? Building { get; set; }
        public IEnumerable<Product>? Products { get; set; }

    }
}
