using Cart.Lib.Dtos;
using Cart.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace Cart.Web.Pages
{
    public class ShoppingCartBase : ComponentBase
    {
        [Inject]
        public required IShoppingCartService ShoppingCartService { get; set; }
        public List<CartItemDto>? ShoppingCartItems { get; set; }
        public string? ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                ShoppingCartItems = await ShoppingCartService.GetItems(HardCoded.UserId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Getting Cart Error : " + ex.Message);
                ErrorMessage = ex.Message;
            }
        }

        public async Task DeleteItem(int id)
        {
            await ShoppingCartService.DeleteItem(id);
            RemoveCartItem(id);
        }

        private void RemoveCartItem(int id)
        {
            var cartItemDto = GetCartItem(id);
            if (cartItemDto is not null && ShoppingCartItems is not null)
                ShoppingCartItems.Remove(cartItemDto);
        }

        private CartItemDto? GetCartItem(int id) => ShoppingCartItems?.FirstOrDefault(s => s.Id == id);
    }
}