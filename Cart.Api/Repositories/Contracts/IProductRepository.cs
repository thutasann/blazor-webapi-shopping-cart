using Cart.Api.Entities;

namespace Cart.Api.Repositories.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<IEnumerable<ProductCategory>> GetCategoriesAsync();
        Task<Product> GetProductAsync(int id);
        Task<ProductCategory> GetCategoryAsync(int id);
    }
}