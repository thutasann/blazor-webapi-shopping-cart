using Cart.Api.Entities;
using Cart.Lib.Dtos;

namespace Cart.Api.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<ProductDto> ConvertToDto(this IEnumerable<Product> products, IEnumerable<ProductCategory> productCategories)
        {
            var productDto = (from product in products
                              join productCategory in productCategories
                              on product.CategoryId equals productCategory.Id
                              select new ProductDto
                              {
                                  Id = product.Id,
                                  Name = product.Name,
                                  Description = product.Description,
                                  ImageURL = product.ImageURL,
                                  Price = product.Price,
                                  Qty = product.Qty,
                                  CategoryId = product.CategoryId,
                                  CategoryName = productCategory.Name
                              }).ToList();
            return productDto;
        }

        public static ProductDto ConvertToDto(this Product product, ProductCategory productCategory)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImageURL = product.ImageURL,
                Price = product.Price,
                Qty = product.Qty,
                CategoryId = product.CategoryId,
                CategoryName = productCategory.Name
            };
        }
    }
}