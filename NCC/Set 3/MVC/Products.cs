using System.ComponentModel.DataAnnotations;

namespace set3_EF.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
