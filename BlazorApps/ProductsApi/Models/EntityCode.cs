using Microsoft.EntityFrameworkCore;

namespace ProductsApi.Models 
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public double Price { get; set; }
    }

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {
                
        }

        public DbSet<Product> Products { get; set; }
    }
}