using Cart.Lib.Dtos;

namespace Cart.Web.Services.Contracts
{
    public interface IShoppingCartService
    {
        Task<List<CartItemDto>?> GetItems(int userId);
        Task<CartItemDto?> AddItem(CartItemToAddDto cartItemToAddDto);
        Task<CartItemDto?> DeleteItem(int id);
        Task<CartItemDto?> UpdateQuantity(CartItemQtyUpdateDto cartItemQtyUpdateDto);
        event Action<int> OnShoppingCartChanged;
        /// <summary>
        /// Shopping Cart Item Count Update Raise Event
        /// </summary>
        /// <param name="totalQty"></param>
        void RaiseEventOnShoppingCartChanged(int totalQty);
    }
}