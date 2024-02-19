using System.ComponentModel.DataAnnotations;

namespace Primary.Domain
{
    public class Moneda
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Simbolo { get; set; }
        public string Iso { get; set; }
        public int Codigo { get; set; }
    }
}
