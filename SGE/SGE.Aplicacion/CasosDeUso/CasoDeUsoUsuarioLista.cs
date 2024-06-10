namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioLista(IServicioAutorizacion autorizacion, IRepositorioUsuario usuario)
{
    public void Ejecutar(int ID)
    {
        if(autorizacion.PoseeElPermiso(usuario.BuscarId(ID), PermisoAdm.ListarUsuarios))
        {
            usuario.ListarUsuarios();
        }
    }
}