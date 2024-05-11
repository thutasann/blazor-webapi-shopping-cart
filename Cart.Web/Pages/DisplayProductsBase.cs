using Cart.Lib.Dtos;
using Microsoft.AspNetCore.Components;

namespace Cart.Web.Pages
{
    public class DisplayProductsBase : ComponentBase
    {
        [Parameter]
        public required IEnumerable<ProductDto> Products { get; set; }
    }
}