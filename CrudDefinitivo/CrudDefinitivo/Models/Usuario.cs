using System.ComponentModel.DataAnnotations;

namespace CrudDefinitivo.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Ingrese Nombres")]
        public string Name { get; set; }

        public int Edad { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

