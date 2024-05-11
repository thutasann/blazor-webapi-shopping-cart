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

        public async Task<CartItemDto?> DeleteItem(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/cart/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<CartItemDto>();
                }
                return default;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Get Items error : {ex.Message}");
                throw;
            }
        }

        public async Task<List<CartItemDto>?> GetItems(int userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/cart/{userId}/GetItems");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<CartItemDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<CartItemDto>>();
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