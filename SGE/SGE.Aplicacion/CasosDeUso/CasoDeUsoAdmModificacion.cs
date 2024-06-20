using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoAdmModificacion(IUsuarioRepositorio repoUsuario, IServicioAutorizacion autorizacion)
{
    public void EjecutarAdm(int idAdm, Usuario usuario)
    {
        if(autorizacion.PoseeElPermiso(repoUsuario.BuscarUsuario(idAdm), "UsuariosModificacion"))
        {
            repoUsuario.ModificarUsuario(usuario);
        }
    }

    public void EjecutarUser(Usuario usuario)
    {
        repoUsuario.ModificarUsuario(usuario);
    }
}