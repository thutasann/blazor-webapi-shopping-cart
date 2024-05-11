using Cart.Api.Data;
using Cart.Api.Entities;
using Cart.Api.Repositories.Contracts;
using Cart.Lib.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Cart.Api.Repositories.Implementations
{
    public class ShoppingCartRespository(AppDbContext appDbContext, ILogger<ShoppingCartRespository> logger) : IShopppingCartRepository
    {

        private readonly AppDbContext _context = appDbContext;
        private readonly ILogger<ShoppingCartRespository> _logger = logger;

        public async Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto)
        {
            if (await CartItemExists(cartItemToAddDto.CartId, cartItemToAddDto.ProductId) == false)
            {
                CartItem? item = await (
                    from product in _context.Products
                    where product.Id == cartItemToAddDto.ProductId
                    select new CartItem
                    {
                        CartId = cartItemToAddDto.CartId,
                        ProductId = product.Id,
                        Qty = cartItemToAddDto.Qty
                    }
                ).SingleOrDefaultAsync();

                if (item != null)
                {
                    var result = await _context.CartItems.AddAsync(item);
                    await _context.SaveChangesAsync();
                    return result.Entity;
                }
            }

            return null!;
        }

        public async Task<CartItem?> DeleteItem(int id)
        {
            var item = await _context.CartItems.FindAsync(id);
            if (item != null)
            {
                _context.CartItems.Remove(item);
                await _context.SaveChangesAsync();
            }
            return item;
        }

        public async Task<CartItem?> GetItemAsync(int id)
        {
            return await (from cart in _context.Carts
                          join cartItem in _context.CartItems
                          on cart.Id equals cartItem.CartId
                          where cartItem.Id == id
                          select new CartItem
                          {
                              Id = cartItem.Id,
                              ProductId = cartItem.ProductId,
                              Qty = cartItem.Qty,
                              CartId = cart.Id
                          }
            ).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CartItem>> GetItems(int userId)
        {
            return await (from cart in _context.Carts
                          join cartItem in _context.CartItems
                          on cart.Id equals cartItem.CartId
                          where cart.UserId == userId
                          select new CartItem
                          {
                              Id = cartItem.Id,
                              ProductId = cartItem.ProductId,
                              Qty = cartItem.Qty,
                              CartId = cart.Id
                          }
                        ).ToListAsync();
        }

        public Task<CartItem> UpdateQty(int id, CartItemQtyUpdateDto cartItemQtyUpdateDto)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> CartItemExists(int cartId, int productId)
        {
            return await _context.CartItems.AnyAsync(c => c.CartId == cartId && c.ProductId == productId);
        }
    }
}