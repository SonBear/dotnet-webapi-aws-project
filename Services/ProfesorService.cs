using entrega1.Models;

namespace entrega1.Services;

public static class ProfesorService
{
    static List<Profesor> Profesores { get; }
    static int nextId = 3;
    static ProfesorService()
    {
        Profesores = new List<Profesor>
        {
            new Profesor { Id = 1, EmployeeNum=12 ,Names = "Sour", LastNames = "Cream", ClaseHrs = 10},
            new Profesor { Id = 2, EmployeeNum=123 ,Names = "Time", LastNames = "Baked", ClaseHrs = 10},
        };
    }

    public static List<Profesor> GetAll() => Profesores;

    public static Profesor? Get(int id) => Profesores.FirstOrDefault(p => p.Id == id);

    public static void Add(Profesor Profesor)
    {
        Profesor.Id = nextId++;
        Profesores.Add(Profesor);
    }

    public static void Delete(int id)
    {
        var Profesor = Get(id);
        if(Profesor is null)
            return;

        Profesores.Remove(Profesor);
    }

    public static void Update(Profesor Profesor)
    {
        var index = Profesores.FindIndex(p => p.Id == Profesor.Id);
        if(index == -1)
            return;

        Profesores[index] = Profesor;
    }
}