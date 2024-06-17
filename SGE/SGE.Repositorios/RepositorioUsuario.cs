using Microsoft.EntityFrameworkCore.Metadata;
using SGE.Aplicacion;

namespace SGE.Repositorios;

public class RepositorioUsuario : IUsuarioRepositorio
{
    public List<Usuario> ListarUsuarios()
    {
        List<Usuario> listaUsuario = new List<Usuario>();
        using (var context = new DatosContext())
        {
            foreach(Usuario usuario in context.Usuarios)
            {
                listaUsuario.Add(usuario);
            }
        }
        if(listaUsuario == null)
        {
            throw new RepositorioException("No existen usuarios");
        }
        else
        {
            return listaUsuario;
        }
    }

    public Usuario BuscarUsuario(int idUsuario)
    {
        Usuario? usuario;
        using (var context = new DatosContext())
        {
            var query = context.Usuarios.Where(u => u.Id == idUsuario).SingleOrDefault();

            usuario = query;
        
        }
        if(usuario == null)
        {
            throw new RepositorioException("No existe el usuario con esa ID");
        }
        else
        {
            return usuario;
        }
    }

    public void EliminarUsuario(int idUsuario)
    {
        Usuario? usuario;
        using (var context = new DatosContext())
        {
            var query = context.Usuarios.Where(u => u.Id == idUsuario).SingleOrDefault();

            if(query != null)
            {
                context.Remove(query);
                context.SaveChanges();
            }
            usuario = query;
        }
        if(usuario == null)
        {
            throw new RepositorioException("No existe el usuario a eliminar");
        }
    }

    public void ModificarUsuario(Usuario usuario)
    {
        bool ok = false;
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
        if(ok)
        {
            throw new RepositorioException("No existe el usuario a modificar");
        }

    }
}