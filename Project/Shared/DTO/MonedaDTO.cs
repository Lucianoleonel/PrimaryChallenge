using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Project.Shared
{
    public class MonedaDTO
    {
        public MonedaDTO(
            string simbolo,
            string iso,
            int? codigo,
            string descripcion
        )
        {
            this.Simbolo = simbolo;
            this.Iso = iso;
            this.Codigo = codigo;
            this.Descripcion = descripcion;
        }
        public MonedaDTO()
        {
            
        }

        [JsonProperty("simbolo")]
        [JsonPropertyName("simbolo")]
        public string Simbolo { get; }

        [JsonProperty("iso")]
        [JsonPropertyName("iso")]
        public string Iso { get; }

        [JsonProperty("codigo")]
        [JsonPropertyName("codigo")]
        public int? Codigo { get; }

        [JsonProperty("descripcion")]
        [JsonPropertyName("descripcion")]
        public string Descripcion { get; }
    }

}
