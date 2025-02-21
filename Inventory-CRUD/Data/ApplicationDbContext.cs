using Inventory_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory_CRUD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products {  get; set; }
    }
}
