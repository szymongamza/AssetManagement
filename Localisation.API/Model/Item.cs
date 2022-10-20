using System.ComponentModel.DataAnnotations;

namespace Localisation.API.Model
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        public int ExternalId { get; set; }
    }
}
