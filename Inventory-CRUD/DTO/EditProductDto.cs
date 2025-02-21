namespace Inventory_CRUD.DTO
{
    public class EditProductDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public string? Status { get; set; }
    }
}
