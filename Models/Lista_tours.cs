using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appAgencia.Models
{
    public class Region
    {
        [Key]
        public int id_region { get; set; }

        public int num_tours { get; set; } = 0;

        [Required]
        [StringLength(500)]
        public string desc_region { get; set; } = string.Empty; // <- inicializado

        [StringLength(200)]
        public string ImgReg_url { get; set; } = string.Empty; // <- inicializado

        public ICollection<Destino> Destinos { get; set; } = new List<Destino>(); // <- inicializado
    }

    public class Destino
    {
        [Key]
        public int id_destino { get; set; }

        [ForeignKey("Region")]
        public int id_region { get; set; }

        [Required]
        [StringLength(100)]
        public string nom_destino { get; set; } = string.Empty; // <- inicializado

        [Required]
        [StringLength(1000)]
        public string desc_destino { get; set; } = string.Empty; // <- inicializado

        [Column(TypeName = "numeric(10,2)")]
        public decimal precio_tour { get; set; }

        public int num_entradas { get; set; } = 0;

        [StringLength(50)]
        public string time_tour { get; set; } = string.Empty; // <- inicializado

        [StringLength(200)]
        public string ImgDest_url { get; set; } = string.Empty; // <- inicializado

        public Region Region { get; set; } = null!; // <- le dices que "nunca" será null
    }
}
