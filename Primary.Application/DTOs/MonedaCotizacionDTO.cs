using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Primary.Application.DTOs
{
    public class MonedaCotizacionDTO
    {
        
        [System.Text.Json.Serialization.JsonConstructor]
        public MonedaCotizacionDTO(
            [JsonProperty("codMoneda")] int? codMoneda,
            [JsonProperty("descripcion")] string descripcion,
            [JsonProperty("simbolo")] string simbolo,
            [JsonProperty("iso")] string iso,
            [JsonProperty("cotizacion")] int? cotizacion,
            [JsonProperty("fecha")] DateTime? fecha,
            [JsonProperty("cotizacionValuacion")] int? cotizacionValuacion
        )
        {
            this.CodMoneda = codMoneda;
            this.Descripcion = descripcion;
            this.Simbolo = simbolo;
            this.Iso = iso;
            this.Cotizacion = cotizacion;
            this.Fecha = fecha;
            this.CotizacionValuacion = cotizacionValuacion;
        }

        #region Properties

        [JsonProperty("codMoneda")]
        public int? CodMoneda { get; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; }

        [JsonProperty("simbolo")]
        public string Simbolo { get; }

        [JsonProperty("iso")]
        public string Iso { get; }

        [JsonProperty("cotizacion")]
        public int? Cotizacion { get; }

        [JsonProperty("fecha")]
        public DateTime? Fecha { get; }

        [JsonProperty("cotizacionValuacion")]
        public int? CotizacionValuacion { get; }

        #endregion
    }

}
