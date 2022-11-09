using entrega1.Models;

namespace entrega1.Services;

public static class AlumnoService
{
    static List<Alumno> Alumnos { get; }
    static int nextId = 3;
    static AlumnoService()
    {
        Alumnos = new List<Alumno>
        {
            new Alumno { Id = 1, Names = "Italian", LastNames = "been", Tuition = "A190", GradeAvg=10.0},
            new Alumno { Id = 2, Names = "Classic", LastNames = "Italian", Tuition = "A1901", GradeAvg=10.0},
        };
    }

    public static List<Alumno> GetAll() => Alumnos;

    public static Alumno? Get(int id) => Alumnos.FirstOrDefault(p => p.Id == id);

    public static void Add(Alumno Alumno)
    {
        Alumno.Id = nextId++;
        Alumnos.Add(Alumno);
    }

    public static void Delete(int id)
    {
        var Alumno = Get(id);
        if(Alumno is null)
            return;

        Alumnos.Remove(Alumno);
    }

    public static void Update(Alumno Alumno)
    {
        var index = Alumnos.FindIndex(p => p.Id == Alumno.Id);
        if(index == -1)
            return;

        Alumnos[index] = Alumno;
    }
}