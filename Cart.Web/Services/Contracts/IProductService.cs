using Cart.Lib.Dtos;

namespace Cart.Web.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>?> GetProductsAsync();
        Task<ProductDto?> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductCategoryDto>?> GetProductCategories();
    }
}