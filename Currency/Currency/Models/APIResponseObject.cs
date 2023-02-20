using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Currency.Models
{
    public class APIResponseObject
    {
        [JsonProperty("error")]
        public int Error;

        [JsonProperty("error_message")]
        public string ErrorMessage;

        [JsonProperty("amount")]
        public decimal Amount;
    }
}
