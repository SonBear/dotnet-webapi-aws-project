namespace entrega1.Models;

using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

[Table("Profesores")]
public class Profesor
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("numeroEmpleado")]
    public int EmployeeNum { get; set; }

    [JsonPropertyName("nombres")]
    public string? Names { get; set; }

    [JsonPropertyName("apellidos")]
    public string? LastNames { get; set; }

    [JsonPropertyName("horasClase")]
    public int ClaseHrs { get; set; }
}