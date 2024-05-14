using Cart.Lib.Dtos;
using Cart.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace Cart.Web.Pages
{
    public class ProductDetailsBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public required IProductService ProductService { get; set; }

        [Inject]
        public required IShoppingCartService ShoppingCartService { get; set; }

        [Inject]
        public required IManageProductsLocalStorageService ManageProductsLocalStorageService { get; set; }

        [Inject]
        public required IManageCartItemsLocalStorageService ManageCartItemsLocalStorageService { get; set; }

        [Inject]
        public required NavigationManager NavigationManager { get; set; }

        public ProductDto? Product { get; set; }

        public string? ErrorMessage { get; set; }
        private List<CartItemDto>? ShoppingCartItems { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                ShoppingCartItems = await ManageCartItemsLocalStorageService.GetCollection();
                Product = await GetProductById(Id);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        protected async Task HandleAddToCart(CartItemToAddDto cartItemToAddDto)
        {
            try
            {
                var cartItemDto = await ShoppingCartService.AddItem(cartItemToAddDto);
                NavigationManager.NavigateTo("/cart");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Handle Add To Cart Error {ex.Message}");
            }
        }

        private async Task<ProductDto> GetProductById(int id)
        {
            var productDtos = await ManageProductsLocalStorageService.GetCollection();

            if (productDtos != null)
            {
                return productDtos.SingleOrDefault(p => p.Id == id)!;
            }
            return null!;
        }
    }
}