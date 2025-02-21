using Inventory.Models;

namespace Inventory.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Product>>("api/product");
        }

        public async Task AddProductAsync(Product product)
        {
            await _httpClient.PostAsJsonAsync("api/product", product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _httpClient.PutAsJsonAsync($"api/product/{product.Id}", product);
        }

        public async Task DeleteProductAsync(long id)
        {
            await _httpClient.DeleteAsync($"api/product/{id}");
        }
    }
}
