using System.ComponentModel.DataAnnotations;

namespace AssetManagement.API.Dtos.RoomDtos
{
    public class RoomCreateDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Floor { get; set; }
        [Required]
        public int BuildingId { get; set; }
    }
}
