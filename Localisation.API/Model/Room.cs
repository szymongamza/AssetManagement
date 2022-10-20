using System.ComponentModel.DataAnnotations;

namespace Localisation.API.Model
{
    public class Room
    {
        public int Id { get; set; }
        [Required]
        public int RoomNumber { get; set; }
        [Required]
        public int Floor { get; set; }
        public IEnumerable<Item> Items { get; set; } = Enumerable.Empty<Item>();
        public IEnumerable<Employee> Employees { get; set; } = Enumerable.Empty<Employee>();

    }
}
