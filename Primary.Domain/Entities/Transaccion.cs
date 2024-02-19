using Primary.Domain.Exceptions;
using System.Text;

namespace Primary.Domain.Entities
{

    public class Transaccion
    {
        // Id del cliente asociado a la transacción
        public int Id { get; set; }        
        public int ClienteId { get; set; }
        // Id de la moneda involucrada en la transacción
        public int MonedaId { get; set; } 
        public decimal MontoOperado { get; set; }
        //Tipo de Cambio de Moneda que se obtiene del servicio
        public decimal TipoCambio { get; set; }
        //Descripcion del Tipo de Cambio que se obtiene del servicio
        public string? TipoCambioDescripcion { get; set; }
        //Fecha de Transaccion
        public DateTime Fecha { get; set; }
        // Tipo de transacción (Compra o Venta)
        public string TipoOperacion { get; set; }

    }   
}
