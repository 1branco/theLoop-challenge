using Ecommerce.Models;
using Ecommerce.Services.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ecommerce.Services
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory HttpClientFactory;
        private readonly HttpClient HttpClient;

        private const string CategoriesEndpoint = "/category";
        private const string ProductsEndpoint = "/products";

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
            HttpClient = HttpClientFactory.CreateClient();
        }

        public async Task<IList<Category>> GetAllCategories()
        {
            var response = await HttpClient.GetAsync(ProductsEndpoint + CategoriesEndpoint);

            var result = await response.Content.ReadAsStringAsync();

            var categories = JsonConvert.DeserializeObject<IList<Category>>(result);

            return categories;
        }

        public async Task<IList<Product>> GetAllProducts()
        {
            var response = await HttpClient.GetAsync(ProductsEndpoint);

            var result = await response.Content.ReadAsStringAsync();

            var products = JsonConvert.DeserializeObject<IList<Product>>(result);
            
            return products;
        }

        public async Task<IList<Product>> GetProductsByCategory(string categoryName)
        {
            var response = await HttpClient.GetAsync(ProductsEndpoint + CategoriesEndpoint + "/" + categoryName);

            var result = await response.Content.ReadAsStringAsync();

            var productsByCategory = JsonConvert.DeserializeObject<IList<Product>>(result);

            return productsByCategory;
        }

        public async Task<Product> GetProductById(int Id)
        {
            var response = await HttpClient.GetAsync(ProductsEndpoint + "/" + Id);

            var result = await response.Content.ReadAsStringAsync();

            var product = JsonConvert.DeserializeObject<Product>(result);

            return product;
        }
    }
}
