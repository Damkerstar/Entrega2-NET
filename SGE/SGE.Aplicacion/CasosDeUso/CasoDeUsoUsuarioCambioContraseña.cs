namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioCambioContraseña(IServicioAutorizacion autorizacion, IRepositorioUsuario usuario)
{
    public void Ejecutar(int idAdm,int id)
    {

        if(autorizacion.PoseeElPermiso(usuario.BuscarUsuario(idAdm), PermisoAdm.))
        {
            usuario.EliminarUsuario(id);
        }
    }
}