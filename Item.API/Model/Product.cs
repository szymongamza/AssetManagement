using System.ComponentModel.DataAnnotations;

namespace Item.API.Model
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string ManufacturerSerialNumber { get; set; }
        public DateTime DateTimeOfBuy { get; set; } 
        public DateTime DateTimeOfNextMaintainance { get; set; }
        public DateTime DateTimeOfLastMaintainance { get; set; }
        public DateTime DateTimeOfEndOfGuarantee { get; set; }
        public string AdditionalDescription { get; set; }
        [Required]
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public Guid ItemGuid { get; set; } = Guid.NewGuid();

    }
}
