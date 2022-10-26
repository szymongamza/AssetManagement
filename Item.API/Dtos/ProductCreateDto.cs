using System.ComponentModel.DataAnnotations;

namespace Item.API.Dtos
{
    public class ProductCreateDto
    {
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
    }
}
