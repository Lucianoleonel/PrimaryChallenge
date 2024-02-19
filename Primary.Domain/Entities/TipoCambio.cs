using System.ComponentModel.DataAnnotations;

namespace Primary.Domain.Entities
{
    public class TipoCambio
    {
        [Key]
        public int Id { get; set; }
        public string Origen { get; set; }
        public decimal Comprador { get; set; }
        public decimal Vendedor { get; set; }
        public Moneda Moneda { get; set; }
        //public Moneda MonedaId { get; set; }

    }
}
