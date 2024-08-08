using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models;

/*
 * CORS is a security measure implemented by http to disable cross origin requests. 
 * EnableCors is a Middleware that is used to remove this security.
 * AddCors to the services
 * Use cors for the Application.
 * Set the attribute EnableCors for the Controller level. 
 */
namespace ProductsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("cors")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext context;
        public ProductsController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet("AllProducts")]
        public List<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }

        [HttpGet("AllProducts/{id}")]
        public Product GetProductById(int id)
        {
            return context.Products.FirstOrDefault(p => p.ProductId == id);
        }

        [HttpPost("AllProducts")]
        public string AddProduct(Product product)
        {
            try
            {
                context.Products.Add(product);
                context.SaveChanges();
                return "Product added successfully";
            }
            catch (Exception ex)
            {
                return ex.Message + ex.StackTrace;
            }
        }

        [HttpPut]
        public string UpdateProduct(Product product)
        {
            var p = context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (p != null)
            {
                p.ProductName = product.ProductName;
                p.Price = product.Price;
                context.SaveChanges();
                return "Product updated successfully";
            }
            else
                throw new Exception("Product not found to update");
        }

        [HttpDelete]
        public string DeleteProduct(int id)
        {
            var found = context.Products.FirstOrDefault(x => x.ProductId == id);
            if (found != null)
            {
                context.Products.Remove(found);
                context.SaveChanges();
                return "Product updated successfully";
            }
            else
            {
                throw new Exception("{Product not found to delete");
            }
        }
    }
}
