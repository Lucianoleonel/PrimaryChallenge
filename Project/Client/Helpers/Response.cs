using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Project.Client.Helpers
{
    public class RootClass
    {
        [JsonProperty("code")]
        [JsonPropertyName("code")]
        public int? Code { get; set; }

        [JsonProperty("data")]
        [JsonPropertyName("data")]
        public object? Data { get; set; }
                    
        [JsonProperty("message")]
        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }

}
