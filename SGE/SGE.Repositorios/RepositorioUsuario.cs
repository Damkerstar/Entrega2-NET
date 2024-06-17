using Microsoft.EntityFrameworkCore.Metadata;
using SGE.Aplicacion;

namespace SGE.Repositorios;

public class RepositorioUsuario : IUsuarioRepositorio
{

    public void AgregarUsuario(Usuario user)
    {

        DatosSqlite.Inicializar();

        using(var context = new DatosContext())
        {

            context.Add(user);
            context.SaveChanges();

            var query = context.Usuarios.Where(u => u.Id == 1).SingleOrDefault();

            if(query != null && query.Permisos != null)
            {
                
                foreach(Permiso p in Enum.GetValues(typeof(Permiso)))
                {
                    String nuevoPermiso = $"{p}";
                    query.Permisos.Add((nuevoPermiso));
                }
                
            }

        }

    }

    public List<Usuario> ListarUsuarios()
    {
        List<Usuario> listaUsuario = new List<Usuario>();
        DatosSqlite.Inicializar();

        using (var context = new DatosContext())
        {
            foreach(Usuario usuario in context.Usuarios)
            {
                listaUsuario.Add(usuario);
            }
        }

        return listaUsuario;

    }

    public Usuario BuscarUsuario(int idUsuario)
    {
        Usuario? usuario;
        DatosSqlite.Inicializar();

        using (var context = new DatosContext())
        {
            var query = context.Usuarios.Where(u => u.Id == idUsuario).SingleOrDefault();

            usuario = query;
        
        }

        if(usuario == null)
        {
            throw new RepositorioException("No existe el usuario buscado.");
        }
        else
        {
            return usuario;
        }
    }

    public void EliminarUsuario(int idUsuario)
    {
        Usuario? usuario;
        DatosSqlite.Inicializar();

        using (var context = new DatosContext())
        {
            var query = context.Usuarios.Where(u => u.Id == idUsuario).SingleOrDefault();

            if(query != null && query.Id != 1)
            {
                context.Remove(query);
                context.SaveChanges();
            }
            usuario = query;
        }
        if(usuario == null)
        {
            throw new RepositorioException("No existe el usuario buscado.");
        }
        else if(usuario.Id == 1) throw new RepositorioException("No se puede eliminar este usuario.");
    }

    public void ModificarUsuario(Usuario usuario)
    {
        bool ok = false;
        DatosSqlite.Inicializar();

        using (var context = new DatosContext())
        {
            var query = context.Usuarios.Where(u => u.Id == usuario.Id).SingleOrDefault();

            if(query != null)
            {
                query.Nombre = usuario.Nombre;
                query.CorreoElectronico = usuario.CorreoElectronico;
                query.Apellido = usuario.Apellido;
                context.SaveChanges();
                ok = true;
            }
            
        }
        if(!ok)
        {
            throw new RepositorioException("No existe el usuario buscado.");
        }

    }
}