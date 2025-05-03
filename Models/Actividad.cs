using System;

namespace appAgencia.Models
{
    public class Actividad
{
    public int Id { get; set; }
    public int IdEvento { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public TimeSpan? HoraInicio { get; set; }
    public TimeSpan? HoraFin { get; set; }

    public required Evento Evento { get; set; }
}
}