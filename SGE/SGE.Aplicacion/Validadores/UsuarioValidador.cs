namespace SGE.Aplicacion;
using SGE.Aplicacion.Entidades;
public class UsuarioValidador
{
    public bool ValidarUsuario(Usuario usuario)
    {

        if(string.IsNullOrWhiteSpace(usuario.Nombre) || string.IsNullOrWhiteSpace(usuario.Apellido) || string.IsNullOrWhiteSpace(usuario.CorreoElectronico) || string.IsNullOrWhiteSpace(usuario.Contrasena))
        {
            string msg = "Todos los datos deben estar llenos.";
            throw new ValidacionException(msg);
        }

        return true;

    }
}