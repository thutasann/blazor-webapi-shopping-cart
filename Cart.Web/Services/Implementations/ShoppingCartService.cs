using System.Net.Http.Json;
using Cart.Lib.Dtos;
using Cart.Web.Services.Contracts;

namespace Cart.Web.Services.Implementations
{
    public class ShoppingCartService(HttpClient httpClient) : IShoppingCartService
    {

        private readonly HttpClient _httpClient = httpClient;

        public async Task<CartItemDto?> AddItem(CartItemToAddDto cartItemToAddDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<CartItemToAddDto>("api/cart", cartItemToAddDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default!;
                    }
                    return await response.Content.ReadFromJsonAsync<CartItemDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Add Item HTTP Status {response.StatusCode} Message {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Add Item error : {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<CartItemDto>?> GetItems(int userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/{userId}/GetItems");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<CartItemDto>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<CartItemDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Get Items error : {ex.Message}");
                throw;
            }
        }
    }
}