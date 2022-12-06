using entrega1.Models;

namespace entrega1.Services;

public static class ProfesorService
{
    static List<Profesor> Profesores { get; }

    private static DatabaseContext Database;

    static ProfesorService()
    {
        Profesores = new List<Profesor> { };
        Database = new DatabaseContext();
    }

    public static List<Profesor> GetAll() => Database.Profesores.OrderBy(a => a.Id).ToList();

    public static Profesor? Get(int id) => Database.Profesores.Find(id);

    public static void Add(Profesor Profesor)
    {
        Database.Profesores.Add(Profesor);
        Database.SaveChanges();
    }

    public static void Delete(int id)
    {
        var Profesor = Get(id);
        if (Profesor is null)
            return;

        Database.Profesores.Remove(Profesor);
        Database.SaveChanges();
    }

    public static Profesor Update(Profesor ProfesorDB, Profesor Profesor)
    {
        ProfesorDB.ClaseHrs = Profesor.ClaseHrs;
        ProfesorDB.LastNames = Profesor.LastNames;
        ProfesorDB.Names = Profesor.Names;
        ProfesorDB.EmployeeNum = Profesor.EmployeeNum;
        Database.SaveChanges();
        return ProfesorDB;
    }
}