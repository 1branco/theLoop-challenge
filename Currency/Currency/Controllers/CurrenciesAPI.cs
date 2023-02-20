using Currency.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Currency.Controllers
{
    public class CurrenciesAPI : ICurrenciesAPI
    {
        private readonly IConfiguration Configuration;
        internal const string ApiKey = "DuwkQ78JuUnH6UwX2mQcsVmS6wTGPL";

        public CurrenciesAPI(IConfiguration configuration) 
        {
            Configuration = configuration;
        }

        public async Task<APIResponseObject> ConvertCurrency(string inputCurrency, float inputAmount, string desiredCurrency)
        { 
            using(HttpClient client = new HttpClient())
            {
                var apiKey = Configuration.GetSection("API")["apiKey"] ?? ApiKey;
                
                string baseAddress = string.Format("https://www.amdoren.com/api/currency.php?api_key={0}&from={1}&to={2}&amount={3}", apiKey, inputCurrency, desiredCurrency, inputAmount);
                client.BaseAddress = new Uri(baseAddress);

                var response = await client.GetStringAsync(client.BaseAddress);
                
                var result = JsonConvert.DeserializeObject<APIResponseObject>(response);

                return result;
            }
        }

    }
}
