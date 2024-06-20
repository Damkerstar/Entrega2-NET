using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoUsuarioBaja(IServicioAutorizacion autorizacion, IUsuarioRepositorio repoUsuario)
{
    public void Ejecutar(int idAdm,int id)
    {

        if(autorizacion.PoseeElPermiso(repoUsuario.BuscarUsuario(idAdm), "UsuariosBaja"))
        {
            repoUsuario.EliminarUsuario(id);
        }
    }
}