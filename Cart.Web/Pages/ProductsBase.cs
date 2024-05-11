using Cart.Lib.Dtos;
using Cart.Web.Services.Contracts;
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
        public IEnumerable<ProductDto>? Products { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Products = await ProductService.GetProductsAsync();
            var ShoppingCartItems = await ShoppingCartService.GetItems(HardCoded.UserId);
            int? totalQty = ShoppingCartItems?.Sum(s => s.Qty);
            ShoppingCartService.RaiseEventOnShoppingCartChanged(totalQty ?? 0);
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

        /// <summary>
        /// Get Category from groupedProductsByCategory
        /// </summary>
        /// <param name="groupedProductDto"></param>
        /// <returns></returns>
        protected static string GetCategoryName(IGrouping<int, ProductDto> groupedProductDto)
        {
            return groupedProductDto.FirstOrDefault(pg => pg!.CategoryId == groupedProductDto.Key)!.CategoryName;
        }
    }
}