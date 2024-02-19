using Project.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

    public class CustomerDTO : Entity
    {
        public CustomerDTO()
        {

        }

        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(50, ErrorMessage = "El apellido no puede tener más de 50 caracteres.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "El CUIT es obligatorio.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "El CUIT debe tener 11 dígitos.")]
        public string CUIT { get; set; }

        [StringLength(100, ErrorMessage = "La dirección no puede tener más de 100 caracteres.")]
        public string Address { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "El número de teléfono debe tener 10 dígitos.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "La dirección de correo electrónico no es válida.")]
        public string Email { get; set; }
    }
