namespace entrega1.Services;
using entrega1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class DatabaseContext : DbContext
{
    public DbSet<Alumno> Alumnos { get; set; }
    public DbSet<Profesor> Profesores { get; set; }



    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql("Host=sicei.cuxpctzjohxx.us-east-1.rds.amazonaws.com;Database=sicei;Username=postgres;Password=password");
    }
}