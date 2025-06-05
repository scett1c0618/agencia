using System;
using System.ComponentModel.DataAnnotations;

namespace AgenciaDeViajes.Models
{
    public class EntradaBlog
    {
        public int Id { get; set; }

        [Required]
        public string Ciudad { get; set; } = string.Empty;

        [Required]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        public string FotoUrl { get; set; } = string.Empty;

        [Required]
        public string Contenido { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaPublicacion { get; set; }
    }
}
