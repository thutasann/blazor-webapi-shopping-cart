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

                if (products == null)
                {
                    return NotFound();
                }
                else
                {
                    var productDtos = products.ConvertToDto();
                    return Ok(productDtos);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Product Get Error : {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetProduct([FromRoute] int id)
        {
            try
            {
                var product = await _productRepo.GetProductAsync(id);
                if (product == null)
                {
                    return BadRequest();
                }
                else
                {
                    var productDto = product.ConvertToDto();
                    return Ok(productDto);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Product Get By Id Error : {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet]
        [Route(nameof(GetProductCategories))]
        public async Task<ActionResult<IEnumerable<ProductCategoryDto>>> GetProductCategories()
        {
            try
            {
                var productCategories = await _productRepo.GetCategoriesAsync();
                var productCategoriesDto = productCategories.ConvertToDto();
                return Ok(productCategoriesDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Product Categories Error : {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet]
        [Route("{categoryId:int}/GetItemsByCategory")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItemsByCategory(int categoryId)
        {
            try
            {
                var products = await _productRepo.GetItemsByCategory(categoryId);
                var productDtos = products?.ConvertToDto();
                return Ok(productDtos);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Products By Category Error : {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
    }
}