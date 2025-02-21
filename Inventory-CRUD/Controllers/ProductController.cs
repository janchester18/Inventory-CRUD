using Inventory_CRUD.Data;
using Inventory_CRUD.DTO;
using Inventory_CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        //hello

        [HttpGet]
        public async Task<IActionResult> GetProducts(int page = 1, int pageSize = 10)
        {
            var skip = (page - 1) * pageSize;
            var totalRecords = await _context.Products.CountAsync();

            var products = await _context.Products
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductDto request)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Category = request.Category,
                Quantity = request.Quantity,
                Price = request.Price,
                Status = request.Status ?? "In-stock",
                UpdatedAt = DateTime.Now,
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct (int id, [FromBody] EditProductDto request)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return BadRequest("Product not found!");
            }

            product.Name = request.Name ?? product.Name;
            product.Description = request.Description ?? product.Description;
            product.Category = request.Category ?? product.Category;
            product.Quantity = request.Quantity ?? product.Quantity;
            product.Price = request.Price ?? product.Price;
            product.Status = request.Status ?? product.Status;

            await _context.SaveChangesAsync();

            return Ok(new {message = "Product updated successfully!"});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct (int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return BadRequest("Product not found!");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(new { message = "The product has been successfully deleted successfully." });
        }
    }
}
