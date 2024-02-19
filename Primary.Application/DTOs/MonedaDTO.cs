using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Primary.Application.DTOs
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
