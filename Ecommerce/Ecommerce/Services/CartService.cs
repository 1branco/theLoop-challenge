using Ecommerce.Models;
using Ecommerce.Services.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ecommerce.Services
{
    public class CartService : ICartService
    {
        private readonly IHttpClientFactory HttpClientFactory;
        private readonly HttpClient HttpClient;

        private const string CartsEndpoint = "carts/";

        public CartService(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
            HttpClient = HttpClientFactory.CreateClient();
        }

        public async Task<IList<Cart>> GetAllCarts()
        {
            var response = await HttpClient.GetAsync(CartsEndpoint);

            var result = await response.Content.ReadAsStringAsync();

            var carts = JsonConvert.DeserializeObject<IList<Cart>>(result);

            return carts;
        }

        public async Task<Cart> GetCart(int cartId)
        {
            var response = await HttpClient.GetAsync(CartsEndpoint + cartId);

            var result = await response.Content.ReadAsStringAsync();

            var cart = JsonConvert.DeserializeObject<Cart>(result);

            return cart;
        }

        public async Task<Cart> UpdateCart(Cart cart)
        {
            var response = await HttpClient.PutAsync(CartsEndpoint + cart.Id,
                new StringContent(JsonConvert.SerializeObject(cart), System.Text.Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Cart>(result);
        }

        public async Task<Cart> CreateNewCart(int userId, IList<Product> products)
        {
            var body = new Cart();
            
            var response = await HttpClient.PostAsync(CartsEndpoint,
              new StringContent(JsonConvert.SerializeObject(body), System.Text.Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Cart>(result);            
        }

        public async Task<IList<Cart>> GetCartByUserId(int userId)
        {
            var response = await HttpClient.GetAsync(CartsEndpoint + "user/" + userId);

            var result = await response.Content.ReadAsStringAsync();

            var cart = JsonConvert.DeserializeObject<IList<Cart>>(result);

            return cart;
        }           
    }
}
