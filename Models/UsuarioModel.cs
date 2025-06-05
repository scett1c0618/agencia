using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaDeViajes.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // 👈 Asegura que se autogenere
        public int IdUsuario { get; set; }


        [Required]
        [StringLength(100)]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(100)]
        public string Contrasena { get; set; }

        [Required]
        [StringLength(50)]
        public string Rol { get; set; } = "Admin"; // Solo Admin por ahora
    }
}
