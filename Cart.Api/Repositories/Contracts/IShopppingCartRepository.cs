using Cart.Api.Entities;
using Cart.Lib.Dtos;

namespace Cart.Api.Repositories.Contracts
{
    public interface IShopppingCartRepository
    {
        /// <summary>
        /// Add Cart item
        /// </summary>
        /// <param name="cartItemToAddDto"></param>
        /// <returns></returns>
        Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto);
        /// <summary>
        /// Update Quantity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cartItemQtyUpdateDto"></param>
        /// <returns></returns>
        Task<CartItem> UpdateQty(int id, CartItemQtyUpdateDto cartItemQtyUpdateDto);
        Task<CartItem?> DeleteItem(int id);
        /// <summary>
        /// Get Cart Item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CartItem?> GetItemAsync(int id);
        /// <summary>
        /// Get Cart Items by UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<CartItem>> GetItems(int userId);
    }
}