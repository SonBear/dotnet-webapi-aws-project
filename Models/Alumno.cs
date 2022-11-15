namespace entrega1.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
public class Alumno
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("nombres")]
    public string Names { get; set; }

    [JsonPropertyName("apellidos")]
    public string LastNames { get; set; }

    [JsonPropertyName("matricula")]
    public string Tuition { get; set; }

    [JsonPropertyName("promedio")]
    public double GradeAvg { get; set; }
}