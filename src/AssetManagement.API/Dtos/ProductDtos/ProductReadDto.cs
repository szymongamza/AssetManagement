namespace AssetManagement.API.Dtos.ProductDtos
{
    public class ProductReadDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Manufacturer { get; set; }
        public string? ManufacturerSerialNumber { get; set; }
        public DateTime DateTimeOfBuy { get; set; }
        public DateTime DateTimeOfNextMaintainance { get; set; }
        public DateTime DateTimeOfLastMaintainance { get; set; }
        public DateTime DateTimeOfEndOfGuarantee { get; set; }
        public string? AdditionalDescription { get; set; }
        public int RoomId { get; set; }
        public Guid ItemGuid { get; set; } = Guid.NewGuid();
        public bool EmailNotification { get; set; }
    }
}
