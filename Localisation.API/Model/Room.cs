using System.ComponentModel.DataAnnotations;

namespace Localisation.API.Model
{
    public class Room
    {
        public int Id { get; set; }
        [Required]
        public string RoomNumber { get; set; }
        [Required]
        public int Floor { get; set; }
        [Required]
        public int BuildingId { get; set; }
        public Building Building { get; set; }

    }
}
