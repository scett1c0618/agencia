using System;
using System.Collections.Generic;

namespace AgenciaDeViajes.Models
{
    public class Festividad
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    public string? Descripcion { get; set; }
    public string? Lugar { get; set; }
    public string? ImagenUrl { get; set; }
    public string? Tipo { get; set; }

    public ICollection<Evento> Eventos { get; set; } = new List<Evento>();
}
}
