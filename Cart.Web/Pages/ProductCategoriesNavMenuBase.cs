using Cart.Lib.Dtos;
using Cart.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace Cart.Web.Pages
{
    public class ProductCategoriesNavMenuBase : ComponentBase
    {
        [Inject]
        public required IProductService ProductService { get; set; }

        public IEnumerable<ProductCategoryDto>? ProductCategories { get; set; }
        public string? ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                ProductCategories = await ProductService.GetProductCategories();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Get Product Categories Error : {ex.Message}");
                throw;
            }
        }
    }
}