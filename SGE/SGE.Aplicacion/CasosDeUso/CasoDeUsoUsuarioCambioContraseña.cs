using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoUsuarioCambioContraseña(IServicioAutorizacion autorizacion, IUsuarioRepositorio repoUsuario)
{
    public void Ejecutar(Usuario usuario, int id)
    {

        if(autorizacion.PoseeElPermiso(repoUsuario.BuscarUsuario(id), Permiso.UsuariosModificacion))
        {
            repoUsuario.ModificarUsuario(usuario);
        }
    }
}