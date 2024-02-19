using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Project.Shared
{
    public class MonedaCotizacionRequestDTO
    {
        [JsonProperty("moneda")]
        [JsonPropertyName("moneda")]
        public string Moneda { get; set; }

        [JsonProperty("fecha")]
        [JsonPropertyName("fecha")]
        public DateTime Fecha { get; set; }

        [JsonProperty("mostrarComoCotizacion")]
        [JsonPropertyName("mostrarComoCotizacion")]
        public bool MostrarComoCotizacion { get; set; }
    }

    public class MonedaCotizacionDTO
    {
        
        [System.Text.Json.Serialization.JsonConstructor]
        public MonedaCotizacionDTO(
           [JsonProperty("codMoneda")] int? codMoneda,
           [JsonProperty("descripcion")] string descripcion,
           [JsonProperty("simbolo")] string simbolo,
           [JsonProperty("iso")] string iso,
           [JsonProperty("cotizacion")] double? cotizacion,
           [JsonProperty("fecha")] DateTime? fecha,
           [JsonProperty("cotizacionValuacion")] double? cotizacionValuacion,
           [JsonProperty("tipoCotizacion")] string tipoCotizacion = null
       )
        {
            this.CodMoneda = codMoneda;
            this.Descripcion = descripcion;
            this.Simbolo = simbolo;
            this.Iso = iso;
            this.Cotizacion = cotizacion;
            this.Fecha = fecha;
            this.CotizacionValuacion = cotizacionValuacion;
            this.TipoCotizacion = tipoCotizacion;
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
        public double? Cotizacion { get; }

        [JsonProperty("fecha")]
        public DateTime? Fecha { get; }

        [JsonProperty("cotizacionValuacion")]
        public double? CotizacionValuacion { get; }

        [JsonProperty("tipoCotizacion")]
        public string? TipoCotizacion { get; }

        #endregion

    }
}
