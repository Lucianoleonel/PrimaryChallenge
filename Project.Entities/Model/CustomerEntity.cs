using Project.Abtractions;

namespace Project.Entities.Model
{
    public class CustomerEntity : Entity
    {
        public CustomerEntity()
        {

        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string CUIT { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}