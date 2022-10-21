using System.ComponentModel.DataAnnotations;

namespace Localisation.API.Dtos
{
    public class BuildingCreateDtos
    {
        [Required]
        public string Name { get; set; }
        public string BuildingCode { get; set; }
        [Required]
        public int MinFloor { get; set; }
        [Required]
        public int MaxFloor { get; set; }
    }
}
