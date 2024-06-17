namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioCambioContraseña(IServicioAutorizacion autorizacion, IUsuarioRepositorio usuario)
{
    public void Ejecutar(string contra,int id)
    {

        if(autorizacion.PoseeElPermiso(usuario.BuscarUsuario(id), Permiso.UsuariosModificacion))
        {
            usuario.EliminarUsuario(id);
        }
    }
}