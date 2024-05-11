using Cart.Api.Extensions;
using Cart.Api.Repositories.Contracts;
using Cart.Lib.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Cart.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController(IProductRepository productRepository) : ControllerBase
    {

        private readonly IProductRepository _productRepo = productRepository;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            try
            {
                var products = await _productRepo.GetProductsAsync();
                var productCategories = await _productRepo.GetCategoriesAsync();

                if (products == null || productCategories == null)
                {
                    return NotFound();
                }
                else
                {
                    var productDtos = products.ConvertToDto(productCategories);
                    return Ok(productDtos);
                }
            }
            catch (Exception ex)

            {
                Console.WriteLine($"--> Product Get Error : {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
    }
}