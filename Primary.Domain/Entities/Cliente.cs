using Primary.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Primary.Domain
{
    
    public class Cliente
    {
        [Key]
        public int? Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
    }
}
