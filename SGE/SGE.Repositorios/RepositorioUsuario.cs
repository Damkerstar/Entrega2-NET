using Microsoft.EntityFrameworkCore.Metadata;
using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;

namespace SGE.Repositorios;

public class RepositorioUsuario : IUsuarioRepositorio
{

    public void AgregarUsuario(Usuario user)
    {

        using(var context = new DatosContext())
        {

            context.Add(user);
            context.SaveChanges();

            var query = context.Usuarios.Where(u => u.Id == 1).SingleOrDefault();

            if(query != null && query.Permisos != null)
            {
                
                foreach(Permiso p in Enum.GetValues(typeof(Permiso)))
                {
                    query.Permisos.Add(p);
                }
                
            }

        }

    }

    //Revisar implementación y uso (Listar, Buscar, Buscar último y buscar por etiqueta)
    //Es posible que al haber variables privadas se deba crear un nuevo Constructor?
    //Implementado porque en la teoría se devuelven cosas de esta forma para no devolver
    //un valor original y que pueda causar problemas su modificación.
    //También revisé por varios lados y aparentemente es lo correcto, pero no estoy seguro el manejo de las variables privadas.
    private Usuario Clonar(Usuario u)
    {

        Usuario copia = new Usuario(u);

        return copia;
        //Se devuelve una copia para no devolver el dato original

    }

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

        return listaUsuario;

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

        using (var context = new DatosContext())
        {
            var query = context.Usuarios.Where(u => u.Id == usuario.Id).SingleOrDefault();

            if(query != null)
            {
                query.Nombre = usuario.Nombre;
                query.CorreoElectronico = usuario.CorreoElectronico;
                query.Apellido = usuario.Apellido;
                query.Contrasena = usuario.Contrasena;
                context.SaveChanges();
                ok = true;
            }
            
        }
        if(!ok)
        {
            throw new RepositorioException("No existe el usuario buscado.");
        }

    }

    public bool BuscarCorreo(string correo)
    {
        bool ok = true;
        using (var context = new DatosContext())
        {
            var query = context.Usuarios.Where(u => u.CorreoElectronico == correo).SingleOrDefault();

            if(query != null)
            {
                ok = false;
            }
        }
        return ok;
    }

    public Usuario DevolverPorCorreo(string correo)
    {

        Usuario? u;

        using(var context = new DatosContext())
        {

            var query = context.Usuarios.Where(i => i.CorreoElectronico == correo).SingleOrDefault();
            u = query;

        }

        if(u != null)
        {
            return u;
        }
        else
        {
            return null;
        }
    
    }
}