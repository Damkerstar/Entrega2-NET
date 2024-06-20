using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoUsuarioModificacion(IServicioAutorizacion autorizacion, IUsuarioRepositorio repoUsuario)
{
    public void Ejecutar(Usuario usuario, int id)
    {

        if(autorizacion.PoseeElPermiso(repoUsuario.BuscarUsuario(id), "UsuariosModificacion"))
        {
            repoUsuario.ModificarUsuario(usuario);
        }
    }
}