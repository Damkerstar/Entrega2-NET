namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioBaja(IServicioAutorizacion autorizacion, IUsuarioRepositorio usuario)
{
    public void Ejecutar(int idAdm,int id)
    {

        if(autorizacion.PoseeElPermiso(usuario.BuscarUsuario(idAdm), Permiso.UsuariosBaja))
        {
            usuario.EliminarUsuario(id);
        }
    }
}