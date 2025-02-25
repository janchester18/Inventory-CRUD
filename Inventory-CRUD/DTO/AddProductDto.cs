using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace Inventory_CRUD.DTO
{
    public class AddProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string? Status { get; set; } = "In-stock";
        public string? ImageUrl { get; set; } = "images/default.jpg";
    }
}
