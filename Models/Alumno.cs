namespace entrega1.Models;

using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

[Table("Alumnos")]
public class Alumno
{
    [JsonPropertyName("id")]

    public int Id { get; set; }

    [JsonPropertyName("nombres")]
    public string? Names { get; set; }

    [JsonPropertyName("apellidos")]
    public string? LastNames { get; set; }

    [JsonPropertyName("matricula")]
    public string? Tuition { get; set; }

    [JsonPropertyName("promedio")]
    public double GradeAvg { get; set; }
}