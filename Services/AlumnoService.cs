using entrega1.Models;
namespace entrega1.Services;

public static class AlumnoService
{
    static List<Alumno> Alumnos { get; }
    private static DatabaseContext Database;

    static AlumnoService()
    {
        Database = new DatabaseContext();
        Alumnos = new List<Alumno> { };
    }

    public static List<Alumno> GetAll() => Database.Alumnos.OrderBy(a => a.Id).ToList();

    public static Alumno? Get(int id) => Database.Alumnos.Find(id);

    public static void Add(Alumno Alumno)
    {
        Database.Alumnos.Add(Alumno);
        Database.SaveChanges();
    }

    public static void Delete(int id)
    {
        var Alumno = Get(id);
        if (Alumno is null)
            return;

        Database.Alumnos.Remove(Alumno);
        Database.SaveChanges();
    }

    public static Alumno? Update(Alumno AlumnoDB, Alumno Alumno)
    {
        AlumnoDB.GradeAvg = Alumno.GradeAvg;
        AlumnoDB.LastNames = Alumno.LastNames;
        AlumnoDB.Names = Alumno.Names;
        AlumnoDB.Tuition = Alumno.Tuition;
        Database.SaveChanges();
        return AlumnoDB;
    }
}