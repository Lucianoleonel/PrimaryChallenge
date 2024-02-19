namespace Project.Shared
{

    public class TransaccionDTO
    {
        public int? Id { get; set; }
        public int ClienteId { get; set; }
        public int MonedaId { get; set; } 
        public decimal MontoOperado { get; set; }
        public decimal TipoCambio { get; set; }
        public string? TipoCambioDescripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string? TipoOperacion { get; set; }        
    }

   }
