using Microsoft.EntityFrameworkCore;

namespace SGE.Repositorios;
using SGE.Aplicacion;

public class UsuarioContext : DbContext
{

    public DbSet<Usuario> Usuarios {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=Usuario.sqlite");
    }

}