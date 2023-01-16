namespace AssetManagementAPI.Dtos
{
    public class MaintenanceReadDto
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string? Description { get; set; }
        public int ProductId { get; set; }
    }
}
