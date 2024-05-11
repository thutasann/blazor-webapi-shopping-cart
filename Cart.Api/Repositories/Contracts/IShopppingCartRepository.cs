using Cart.Api.Entities;
using Cart.Lib.Dtos;

namespace Cart.Api.Repositories.Contracts
{
    public interface IShopppingCartRepository
    {
        Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto);
        Task<CartItem> UpdateQty(int id, CartItemQtyUpdateDto cartItemQtyUpdateDto);
        Task<CartItem> DeleteItem(int id);
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