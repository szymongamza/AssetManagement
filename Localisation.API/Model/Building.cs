using System.ComponentModel.DataAnnotations;

namespace Localisation.API.Model
{
    public class Building
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string BuildingCode { get; set; }
        [Required]
        public int MinFloor { get; set; }
        [Required]
        public int MaxFloor { get; set; }
        public IEnumerable<Room>? Rooms { get; set; }
    }
}
