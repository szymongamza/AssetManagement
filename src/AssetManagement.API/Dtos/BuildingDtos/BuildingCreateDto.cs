using System.ComponentModel.DataAnnotations;

namespace AssetManagement.API.Dtos.BuildingDtos
{
    public class BuildingCreateDto
    {
        [Required]
        public string? Name { get; set; }
        public string? BuildingCode { get; set; }
        [Required]
        public int MinFloor { get; set; }
        [Required]
        public int MaxFloor { get; set; }
    }
}
