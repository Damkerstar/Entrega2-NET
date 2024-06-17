namespace SGE.Aplicacion;

public interface IUsuarioRepositorio
{
    Usuario BuscarUsuario(int idUsuario);

    List<Usuario> ListarUsuarios();
}