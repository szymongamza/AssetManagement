using System.ComponentModel.DataAnnotations;

namespace Localisation.API.Model
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public int ExternalId { get; set; }
    }
}
