using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoAdmModificacion(IUsuarioRepositorio repoUsuario, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(int idAdm, Usuario usuario)
    {
        if(autorizacion.PoseeElPermiso(repoUsuario.BuscarUsuario(idAdm), "UsuariosModificacion"))
        {
            repoUsuario.ModificarUsuario(usuario);
        }
        else
        {
            throw new ValidacionException("No posee los permisos necesarios para modificar un usuario.");
        }
    }
    
}