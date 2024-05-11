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
        public required NavigationManager NavigationManager { get; set; }

        public ProductDto? Product { get; set; }

        public string? ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Console.WriteLine("Id => " + Id);
                Product = await ProductService.GetProductByIdAsync(Id);
                Console.WriteLine("Product" + Product?.Name);
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
    }
}