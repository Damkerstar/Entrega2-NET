namespace SGE.Aplicacion;

public class CasoDeUsoAdmModificacion(IUsuarioRepositorio repoUsuario, IServicioAutorizacion autorizacion)
{
    public void EjecutarAdm(int idAdm, Usuario usuario)
    {
        if(autorizacion.PoseeElPermiso(repoUsuario.BuscarUsuario(idAdm), Permiso.UsuariosModificacion))
        {
            repoUsuario.ModificarUsuario(usuario);
        }
    }

    public void EjecutarUser(Usuario usuario)
    {
        repoUsuario.ModificarUsuario(usuario);
    }
}