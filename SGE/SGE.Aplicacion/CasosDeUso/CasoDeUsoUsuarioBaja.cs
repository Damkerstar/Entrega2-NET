namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioBaja(IServicioAutorizacion autorizacion, IRepositorioUsuario usuario)
{
    public void Ejecutar(int idAdm,int id)
    {

        if(autorizacion.PoseeElPermiso(usuario.BuscarUsuario(idAdm), PermisoAdm.UsuariosBaja))
        {
            usuario.EliminarUsuario(id);
        }
    }
}