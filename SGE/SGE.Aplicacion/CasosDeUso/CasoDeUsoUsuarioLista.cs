namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioLista(IServicioAutorizacion autorizacion, IUsuarioRepositorio usuario)
{
    public void Ejecutar(int ID)
    {
        if(autorizacion.PoseeElPermiso(usuario.BuscarUsuario(ID), Permiso.ListarUsuarios))
        {
            usuario.ListarUsuarios();
        }
    }
}