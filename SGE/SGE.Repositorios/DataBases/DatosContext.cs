using Microsoft.EntityFrameworkCore;

namespace SGE.Repositorios;
using SGE.Aplicacion;

public class DatosContext : DbContext
{

    public DbSet<Usuario> Usuarios {get; set;}
    public DbSet<Expediente> Expedientes {get; set;}
    public DbSet<Tramite> Tramites {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=Datos.sqlite");
    }

}