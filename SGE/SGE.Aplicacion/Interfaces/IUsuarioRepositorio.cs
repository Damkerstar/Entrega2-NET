using SGE.Aplicacion;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.Interfaces;

public interface IUsuarioRepositorio
{
    void AgregarUsuario(Usuario usuario);
    Usuario BuscarUsuario(int idUsuario);
    void ModificarUsuario(Usuario usuario);
    List<Usuario> ListarUsuarios();
    void EliminarUsuario(int usuarioId);
}