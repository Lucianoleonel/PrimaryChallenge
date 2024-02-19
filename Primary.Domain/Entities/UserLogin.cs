using Primary.Domain.Entities;

namespace Primary.Domain
{
    // Define las entidades de dominio
    public class UserLogin
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string clientId { get; set; }
    }
}
