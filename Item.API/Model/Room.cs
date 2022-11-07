using System.ComponentModel.DataAnnotations;

namespace Item.API.Model
{
    public class Room
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int ExternalID { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}

