using Cart.Api.Data;
using Cart.Api.Entities;
using Cart.Api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Cart.Api.Repositories.Implementations
{
    public class ProductRepository(AppDbContext context) : IProductRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<ProductCategory>> GetCategoriesAsync()
        {
            var categories = await _context.ProductCategories.ToListAsync();
            return categories;
        }

        public Task<ProductCategory> GetCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }
    }
}