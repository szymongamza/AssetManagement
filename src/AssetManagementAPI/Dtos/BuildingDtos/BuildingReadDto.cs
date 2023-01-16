namespace AssetManagementAPI.Dtos
{
    public class BuildingReadDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? BuildingCode { get; set; }
        public int MinFloor { get; set; }
        public int MaxFloor { get; set; }

    }
}
