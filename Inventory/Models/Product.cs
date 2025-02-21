using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class Product
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "The product name is required.")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "The category is required.")]
        public string Category { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative number.")]
        public int Quantity { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative number.")]
        public decimal Price { get; set; }

        // This can be used to control availability or state.
        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
