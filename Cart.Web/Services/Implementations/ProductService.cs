using System.Net.Http.Json;
using Cart.Lib.Dtos;
using Cart.Web.Services.Contracts;

namespace Cart.Web.Services.Implementations
{
    public class ProductService(HttpClient httpClient, ILogger<ProductService> logger) : IProductService
    {

        private readonly HttpClient _httpClient = httpClient;
        private readonly ILogger<ProductService> _logger = logger;

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            try
            {
                var products = await _httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("api/products");
                return products!;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Products Get Async Error {ex.Message}");
                throw;
            }
        }
    }
}