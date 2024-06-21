namespace SGE.Aplicacion;
using SGE.Aplicacion.Entidades;
public class UsuarioValidador
{
    public bool ValidarUsuario(Usuario usuario, out string msg)
    {

        msg = "";

        if(string.IsNullOrWhiteSpace(usuario.Nombre) || string.IsNullOrWhiteSpace(usuario.Apellido) || string.IsNullOrWhiteSpace(usuario.CorreoElectronico) || string.IsNullOrWhiteSpace(usuario.Contrasena))
        {
            msg += "Todos los datos deben estar llenos.";
        }

        return (msg == "");

    }
}