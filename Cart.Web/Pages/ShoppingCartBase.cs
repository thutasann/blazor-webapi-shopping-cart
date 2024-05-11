using Cart.Lib.Dtos;
using Cart.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Cart.Web.Pages
{
    public class ShoppingCartBase : ComponentBase
    {
        [Inject]
        public required IJSRuntime Js { get; set; }
        [Inject]
        public required IShoppingCartService ShoppingCartService { get; set; }
        public List<CartItemDto>? ShoppingCartItems { get; set; }
        public string? ErrorMessage { get; set; }
        protected string? TotalPrice { get; set; }
        protected int TotalQuantity { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                ShoppingCartItems = await ShoppingCartService.GetItems(HardCoded.UserId);
                CalcualteCartSummaryTotals();
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
            CalcualteCartSummaryTotals();
        }

        public async Task UpdateQty_Input(int id)
        {
            await MakeUpdateQtyButtonVisible(id, true);
        }

        public async Task UpdateQtyCartItem(int id, int qty)
        {
            try
            {
                if (qty > 0)
                {
                    var updateItemDto = new CartItemQtyUpdateDto
                    {
                        CartItemId = id,
                        Qty = qty
                    };

                    var updatedItemDto = await ShoppingCartService.UpdateQuantity(updateItemDto);

                    UpdateItemTotalPrice(updatedItemDto!);
                    CalcualteCartSummaryTotals();
                    await MakeUpdateQtyButtonVisible(id, false);
                }
                else
                {
                    var item = ShoppingCartItems!.FirstOrDefault(s => s.Id == id);
                    if (item != null)
                    {
                        item.Qty = 1;
                        item.TotalPrice = item.Price;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Update Qty Cart Item Error : {ex.Message}");
                throw;
            }
        }

        private async Task MakeUpdateQtyButtonVisible(int id, bool visible)
        {
            await Js.InvokeVoidAsync("MakeUpdateQtyButtonVisible", id, visible);
        }

        private void RemoveCartItem(int id)
        {
            var cartItemDto = GetCartItem(id);
            if (cartItemDto is not null && ShoppingCartItems is not null)
                ShoppingCartItems.Remove(cartItemDto);
        }

        private CartItemDto? GetCartItem(int id) => ShoppingCartItems?.FirstOrDefault(s => s.Id == id);

        private void CalcualteCartSummaryTotals()
        {
            SetTotalPrice();
            SetTotalQuantity();
        }

        private void UpdateItemTotalPrice(CartItemDto cartItemDto)
        {
            var item = GetCartItem(cartItemDto.Id);
            if (item is not null)
            {
                item.TotalPrice = cartItemDto.Price * cartItemDto.Qty;
            }
        }

        private void SetTotalPrice() => TotalPrice = ShoppingCartItems!.Sum(s => s.TotalPrice).ToString("");

        private void SetTotalQuantity() => TotalQuantity = ShoppingCartItems!.Sum(s => s.Qty);

    }
}