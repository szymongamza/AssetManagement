using System.ComponentModel.DataAnnotations;

namespace Localisation.API.Model
{
    public class Building
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string BuildingCode { get; set; } = string.Empty;
        [Required]
        public int MinFloor { get; set; }
        [Required]
        public int MaxFloor { get; set; }
        public IEnumerable<Room> Rooms { get; set; } = Enumerable.Empty<Room>();
    }
}
