using Currency.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;

namespace Currency.Controllers
{
    public class CurrenciesAPI : ICurrenciesAPI
    {
        private readonly IConfiguration Configuration;
        internal const string ApiKey = "DuwkQ78JuUnH6UwX2mQcsVmS6wTGPL";
        internal const string BaseUrl = "https://www.amdoren.com/api/currency.php?api_key=";

        public CurrenciesAPI(IConfiguration configuration) 
        {
            Configuration = configuration;
        }

        public async Task<APIResponseObject> ConvertCurrency(string inputCurrency, float inputAmount, string desiredCurrency)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var apiKey = Configuration.GetSection("API")["apiKey"] ?? ApiKey;
                    var baseUrl = Configuration.GetSection("API")["baseUrl"] ?? BaseUrl;

                    string endpoint = string.Format("{0}{1}&from={2}&to={3}&amount={4}", baseUrl, apiKey, inputCurrency, desiredCurrency, inputAmount);
                    client.BaseAddress = new Uri(endpoint);
                    
                    var response = await client.GetStringAsync(client.BaseAddress);

                    APIResponseObject result = JsonConvert.DeserializeObject<APIResponseObject>(response);

                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
