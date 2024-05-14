using Cart.Lib.Dtos;
using Cart.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Cart.Web.Pages
{
    public class CheckoutBase : ComponentBase
    {
        [Inject]
        public required IJSRuntime Js { get; set; }
        protected IEnumerable<CartItemDto>? ShoppingCartItems { get; set; }
        protected int TotalQty { get; set; }
        protected string PaymentDescription { get; set; } = string.Empty;
        protected decimal PaymentAmount { get; set; }

        [Inject]
        public required IShoppingCartService ShoppingCartService { get; set; }

        [Inject]
        public required IManageCartItemsLocalStorageService ManageCartItemsLocalStorageService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                ShoppingCartItems = await ManageCartItemsLocalStorageService.GetCollection();
                if (ShoppingCartItems is not null)
                {
                    Guid orderGuid = Guid.NewGuid();
                    PaymentAmount = ShoppingCartItems.Sum(p => p.TotalPrice);
                    TotalQty = ShoppingCartItems.Sum(p => p.Qty);
                    PaymentDescription = $"O_{HardCoded.UserId}_{orderGuid}";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Checkout Initialize Err : {ex.Message} ");
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (firstRender)
                {
                    await Js.InvokeVoidAsync("initPayPalButton");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Checkout After Initialize Err : {ex.Message} ");
            }
        }
    }
}