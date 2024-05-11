using Cart.Api.Extensions;
using Cart.Api.Repositories.Contracts;
using Cart.Lib.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Cart.Api.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController(
        IShopppingCartRepository shopppingCartRepository,
        ILogger<CartController> logger,
        IProductRepository productRepository) : ControllerBase
    {
        private readonly IShopppingCartRepository _cartRepo = shopppingCartRepository;
        private readonly IProductRepository _productRepo = productRepository;
        private readonly ILogger<CartController> _logger = logger;

        [HttpGet]
        [Route("{userId:int}/GetItems")]
        public async Task<ActionResult<IEnumerable<CartItemDto>>> GetItems(int userId)
        {
            try
            {
                var cartItems = await _cartRepo.GetItems(userId);
                if (cartItems == null)
                {
                    return NoContent();
                }
                var products = await _productRepo.GetProductsAsync() ?? throw new Exception("No Products exist in the system");

                var cartItmesDto = cartItems.ConvertToDto(products);

                return Ok(cartItmesDto);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Get Cart Items Error : {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CartItemDto>> GetItem(int id)
        {
            try
            {
                var cartItem = await _cartRepo.GetItemAsync(id);
                if (cartItem == null)
                {
                    return NotFound();
                }
                var product = await _productRepo.GetProductAsync(cartItem.ProductId);

                if (product == null)
                {
                    return NotFound();
                }

                var cartItemDto = cartItem.ConvertToDto(product);

                return Ok(cartItemDto);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Get Cart Item Error : {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CartItemDto>> PostItem([FromBody] CartItemToAddDto cartItemDto)
        {
            try
            {
                var newCartItem = await _cartRepo.AddItem(cartItemDto);
                if (newCartItem == null)
                {
                    return NotFound();
                }

                var product = await _productRepo.GetProductAsync(newCartItem.ProductId) ?? throw new Exception($"Something went wrong when attempting to retrieve product {cartItemDto.ProductId}");

                var newCartItemDto = newCartItem.ConvertToDto(product);
                return CreatedAtAction(nameof(GetItem), new { Id = newCartItemDto.Id }, newCartItemDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CartItemDto>> DeleteItem([FromRoute] int id)
        {
            try
            {
                var cartItem = await _cartRepo.DeleteItem(id);
                if (cartItem == null)
                {
                    return NotFound();
                }

                var product = await _productRepo.GetProductAsync(cartItem.CartId);

                if (product == null)
                {
                    return NotFound();
                }

                var cartItemDto = cartItem.ConvertToDto(product);
                return Ok(cartItemDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}