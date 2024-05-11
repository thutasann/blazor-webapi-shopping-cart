using Cart.Lib.Dtos;

namespace Cart.Web.Services.Contracts
{
    public interface IShoppingCartService
    {
        Task<List<CartItemDto>?> GetItems(int userId);
        Task<CartItemDto?> AddItem(CartItemToAddDto cartItemToAddDto);
        Task<CartItemDto?> DeleteItem(int id);
        Task<CartItemDto?> UpdateQuantity(CartItemQtyUpdateDto cartItemQtyUpdateDto);
    }
}