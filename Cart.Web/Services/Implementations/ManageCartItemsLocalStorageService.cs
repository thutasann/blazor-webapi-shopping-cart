using Blazored.LocalStorage;
using Cart.Lib.Dtos;
using Cart.Web.Services.Contracts;

namespace Cart.Web.Services.Implementations
{
    public class ManageCartItemsLocalStorageService(ILocalStorageService localStorageService, IShoppingCartService shoppingCartService) : IManageCartItemsLocalStorageService
    {
        private const string key = "CartItemCollection";
        private readonly ILocalStorageService _localStorage = localStorageService;
        private readonly IShoppingCartService _shoppingCartService = shoppingCartService;

        public async Task<List<CartItemDto>?> GetCollection()
        {
            return await _localStorage.GetItemAsync<List<CartItemDto>>(key)
                    ?? await AddCollection();
        }

        public async Task RemoveCollection()
        {
            await _localStorage.RemoveItemAsync(key);
        }

        public async Task SaveCollection(List<CartItemDto> cartItemDtos)
        {
            await _localStorage.SetItemAsync(key, cartItemDtos);
        }

        private async Task<List<CartItemDto>?> AddCollection()
        {
            var shoppingCartCollection = await _shoppingCartService.GetItems(HardCoded.UserId);

            if (shoppingCartCollection != null)
            {
                await _localStorage.SetItemAsync(key, shoppingCartCollection);
            }

            return shoppingCartCollection;

        }

    }
}