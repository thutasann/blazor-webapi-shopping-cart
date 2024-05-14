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

        public async Task<ProductCategory> GetCategoryAsync(int id)
        {
            var category = await _context.ProductCategories.FirstOrDefaultAsync(c => c.Id == id);
            return category!;
        }

        public async Task<IEnumerable<Product>?> GetItemsByCategory(int id)
        {
            var products = await _context.Products.Include(p => p.ProductCategory).Where(p => p.CategoryId == id).ToListAsync();
            return products;
        }

        public async Task<Product?> GetProductAsync(int id)
        {
            var product = await _context.Products.Include(p => p.ProductCategory).SingleOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var products = await _context.Products.Include(p => p.ProductCategory).ToArrayAsync();
            return products;
        }
    }
}