using Examen01.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace Examen01.Data
{
    public class AppDbContext : DbContext
    {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

    public DbSet<Estudiante> Estudiante { get; set; }
    public DbSet<Carrera> Carrera { get; set; }
    }
}
