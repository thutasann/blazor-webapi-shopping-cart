using Cart.Lib.Dtos;
using Cart.Web.Services.Contracts;
using Cart.Web.Services.Implementations;
using Microsoft.AspNetCore.Components;

namespace Cart.Web.Pages
{
    /// <summary>
    /// Products Page Base Class
    /// </summary>
    public class ProductsBase : ComponentBase
    {
        [Inject]
        public required IProductService ProductService { get; set; }

        [Inject]
        public required IShoppingCartService ShoppingCartService { get; set; }

        [Inject]
        public required IManageProductsLocalStorageService ManageProductsLocalStorageService { get; set; }

        [Inject]
        public required IManageCartItemsLocalStorageService ManageCartItemsLocalStorageService { get; set; }

        public IEnumerable<ProductDto>? Products { get; set; }

        public string? ErrorMessage { get; set; }


        protected override async Task OnInitializedAsync()
        {
            try
            {
                await ClearLocalStorage();

                Products = await ManageProductsLocalStorageService.GetCollection();

                var ShoppingCartItems = await ManageCartItemsLocalStorageService.GetCollection();

                int? totalQty = ShoppingCartItems?.Sum(s => s.Qty);

                ShoppingCartService.RaiseEventOnShoppingCartChanged(totalQty ?? 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Get Grouped Products By Category
        /// </summary>
        /// <returns></returns>
        protected IOrderedEnumerable<IGrouping<int, ProductDto>> GetGroupedProductsByCategory()
        {
            return from product in Products
                   group product by product.CategoryId into prodByCatGroup
                   orderby prodByCatGroup.Key
                   select prodByCatGroup;
        }

        protected static string GetCategoryName(IGrouping<int, ProductDto> groupedProductDto)
        {
            return groupedProductDto.FirstOrDefault(pg => pg!.CategoryId == groupedProductDto.Key)!.CategoryName;
        }

        private async Task ClearLocalStorage()
        {
            await ManageProductsLocalStorageService.RemoveCollection();
            await ManageCartItemsLocalStorageService.RemoveCollection();
        }
    }
}