using System.ComponentModel.DataAnnotations;

namespace Localisation.API.Dtos.MaintenanceDtos
{
    public class MaintenanceCreateDto
    {
        [Required]
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string? Description { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
