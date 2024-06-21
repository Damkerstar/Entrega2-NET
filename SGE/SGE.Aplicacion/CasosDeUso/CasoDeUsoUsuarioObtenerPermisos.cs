using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoUsuarioObtenerPermisos(IServicioAutorizacion autorizacion, IUsuarioRepositorio repoUsuario)
{
    public List<string>? Ejecutar(List<Permiso> permisos, int id)
    {

        if(autorizacion.PoseeElPermiso(repoUsuario.BuscarUsuario(id), "UsuariosModificacion"))
        {
            return repoUsuario.ListaPermisosUsuario(permisos);
        }
        return null;
    }
}