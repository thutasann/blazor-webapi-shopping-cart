using Cart.Lib.Dtos;
using Cart.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace Cart.Web.Pages
{
    public class ShoppingCartBase : ComponentBase
    {
        [Inject]
        public required IShoppingCartService ShoppingCartService { get; set; }
        public IEnumerable<CartItemDto>? ShoppingCartItems { get; set; }
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
    }
}