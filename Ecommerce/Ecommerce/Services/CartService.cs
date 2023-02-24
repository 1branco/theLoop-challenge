using Ecommerce.Models;
using Ecommerce.Services.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
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

        public bool UpdateCart(Cart cart)
        {
            throw new System.NotImplementedException();
        }
    }
}
