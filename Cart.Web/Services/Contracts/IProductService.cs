using Cart.Lib.Dtos;

namespace Cart.Web.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();
    }
}