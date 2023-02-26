using Ecommerce.Models;
using Ecommerce.Services.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ecommerce.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpClientFactory HttpClientFactory;
        private readonly HttpClient HttpClient;

        private const string LoginEndpoint = "auth/login";
        private const string UserEndpoint = "users";

        public UserService(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
            HttpClient = HttpClientFactory.CreateClient();
        }

        public async Task<IList<User>> GetAllUsers(string sort)
        {
            var response = await HttpClient.GetAsync(string.Format($"{UserEndpoint}?sort={sort}"));

            var result = await response.Content.ReadAsStringAsync();

            var users = JsonConvert.DeserializeObject<IList<User>>(result);

            return users;
        }

        public async Task<User> GetUserById(int userId)
        {
            var response = await HttpClient.GetAsync(UserEndpoint + "/" + userId);

            var result = await response.Content.ReadAsStringAsync();

            var users = JsonConvert.DeserializeObject<User>(result); 

            return users;
        }

        public async Task<string> Login(Login login)
        {            
            var response = await HttpClient.PostAsync(LoginEndpoint, 
                new StringContent(JsonConvert.SerializeObject(login), System.Text.Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return result;
        }
    }
}
