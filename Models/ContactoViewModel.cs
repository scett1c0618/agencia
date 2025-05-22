using System.ComponentModel.DataAnnotations;

namespace AgenciaDeViajes.Models
{
    public class ContactoViewModel
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Correo no válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe ingresar un mensaje")]
        public string Comentarios { get; set; }
    }
}
