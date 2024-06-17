namespace SGE.Aplicacion;

public interface IUsuarioRepositorio
{
    Usuario BuscarUsuario(int idUsuario);
    void ModificarUsuario(Usuario usuario);
    List<Usuario> ListarUsuarios();
    void EliminarUsuario(int usuarioId);
}