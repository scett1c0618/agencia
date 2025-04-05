using System.ComponentModel.DataAnnotations;

namespace appAgencia.Models
{
    public class ReservaTour
    {
        [Required]
        public string TipoDocumento { get; set; } = "DNI";

        [Required]
        public string NumeroDocumento { get; set; } = "";

        [Required]
        public string Nombre { get; set; } = "";

        [Required]
        public string ApellidoPaterno { get; set; } = "";

        public string ApellidoMaterno { get; set; } = "";

        [Required, EmailAddress]
        public string CorreoElectronico { get; set; } = "";

        [Required]
        public string Nacionalidad { get; set; } = "";

        [Required]
        public string Genero { get; set; } = "";

        [Required]
        public string TipoTour { get; set; } = "";

        [Required]
        public int NumeroPersonas { get; set; }
    }
}
