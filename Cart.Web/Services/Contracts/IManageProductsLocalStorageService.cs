using Cart.Lib.Dtos;

namespace Cart.Web.Services.Contracts
{
    public interface IManageProductsLocalStorageService
    {
        Task<IEnumerable<ProductDto>?> GetCollection();
        Task RemoveCollection();
    }
}