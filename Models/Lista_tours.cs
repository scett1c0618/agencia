using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appAgencia.Models // Cambia al namespace que estés usando
{
    public class Region
    {
        [Key]
        public int id_region { get; set; }
        
        public int num_tours { get; set; } = 0; // Valor por defecto
        
        [Required]
        [StringLength(500)]
        public string desc_region { get; set; }
        
        [Column(TypeName = "varchar(200)")]
        public string ImgReg_url { get; set; }
        
        public ICollection<Destino> Destinos { get; set; }
    }

    public class Destino
    {
        [Key]
        public int id_destino { get; set; }
        
        [ForeignKey("Region")]
        public int id_region { get; set; }
        
        [Required]
        [StringLength(100)]
        public string nom_destino { get; set; }
        
        [Required]
        [StringLength(1000)]
        public string desc_destino { get; set; }
        
        [Column(TypeName = "decimal(10, 2)")]
        public decimal precio_tour { get; set; }
        
        public int num_entradas { get; set; } = 0; // Valor por defecto
        
        [StringLength(50)]
        public string time_tour { get; set; }
        
        [Column(TypeName = "varchar(200)")]
        public string ImgDest_url { get; set; }
        
        public Region Region { get; set; }
    }
}