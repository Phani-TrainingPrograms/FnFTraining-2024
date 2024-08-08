using BlazerApp.Models;
using System.Net.Http.Json;

namespace BlazerApp.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();

        Task<Product> GetProductByIdAsync(int id);
    }

    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;

        public ProductService(HttpClient client)
        {
            this.httpClient = client;
        }

        //All Http Verbs must be used asynchronously which is achieved in .NET using Tasks. Task<Product> is a task that returns a product object after it completes the task.
        public async Task<Product > GetProductByIdAsync(int id) => await httpClient.GetFromJsonAsync<Product>("AllProducts/{id}");


        public async Task<List<Product>> GetProductsAsync() => await httpClient.GetFromJsonAsync<List<Product>>("AllProducts");
        
    }
}
