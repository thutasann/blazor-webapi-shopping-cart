using Cart.Lib.Dtos;
using Cart.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace Cart.Web.Pages
{
    public class ProductsByCategoryBase : ComponentBase
    {
        [Parameter]
        public int CategoryId { get; set; }

        [Inject]
        public required IProductService ProductService { get; set; }

        [Inject]
        public required IManageProductsLocalStorageService ManageProductsLocalStorageService { get; set; }

        public IEnumerable<ProductDto>? Products { get; set; }
        public string? CategoryName { get; set; }
        public string? ErrorMessage { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                Products = await GetProductCollectionByCategoryId(CategoryId);
                if (Products != null && Products.Count() > 0)
                {
                    var product = Products.FirstOrDefault(p => p.CategoryId == CategoryId);
                    if (product != null)
                    {
                        CategoryName = product.CategoryName;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Console.WriteLine($"Get Products By Category Error : {ex.Message}");
                throw;
            }
        }

        private async Task<IEnumerable<ProductDto>?> GetProductCollectionByCategoryId(int categoryId)
        {
            var productCollection = await ManageProductsLocalStorageService.GetCollection();

            if (productCollection != null)
            {
                return productCollection.Where(p => p.CategoryId == categoryId);
            }
            else
            {
                return await ProductService.GetItemsByCategory(categoryId);
            }

        }
    }
}