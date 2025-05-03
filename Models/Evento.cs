using System;
using System.Collections.Generic;

namespace appAgencia.Models
{
    public class Evento
{
    public int Id { get; set; }
    public int IdFestividad { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public TimeSpan? Hora { get; set; }
    public string? Lugar { get; set; }

    public required Festividad Festividad { get; set; }
    public ICollection<Actividad> Actividades { get; set; } = new List<Actividad>();
}
}