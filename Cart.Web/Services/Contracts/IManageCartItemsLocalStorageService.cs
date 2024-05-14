using Cart.Lib.Dtos;

namespace Cart.Web.Services.Contracts
{
    public interface IManageCartItemsLocalStorageService
    {
        Task<List<CartItemDto>?> GetCollection();
        Task SaveCollection(List<CartItemDto> cartItemDtos);
        Task RemoveCollection();
    }
}