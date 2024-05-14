using Blazored.LocalStorage;
using Cart.Lib.Dtos;
using Cart.Web.Services.Contracts;

namespace Cart.Web.Services.Implementations
{
    public class ManageProductsLocalStorageService(ILocalStorageService localStorageService, IProductService productService) : IManageProductsLocalStorageService
    {

        private const string key = "ProductCollection";
        private readonly ILocalStorageService _localStorage = localStorageService;
        private readonly IProductService _productService = productService;

        public async Task<IEnumerable<ProductDto>?> GetCollection()
        {
            return await _localStorage.GetItemAsync<IEnumerable<ProductDto>>(key) ?? await AddCollection();
        }

        public async Task RemoveCollection()
        {
            await _localStorage.RemoveItemAsync(key);
        }

        private async Task<IEnumerable<ProductDto>?> AddCollection()
        {
            var productCollection = await _productService.GetProductsAsync();

            if (productCollection != null)
            {
                await _localStorage.SetItemAsync(key, productCollection);
            }
            return productCollection;
        }
    }
}