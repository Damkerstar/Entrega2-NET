using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoUsuarioLista(IServicioAutorizacion autorizacion, IUsuarioRepositorio repoUsuario)
{
    public void Ejecutar(int ID)
    {
        if(autorizacion.PoseeElPermiso(repoUsuario.BuscarUsuario(ID), "ListarUsuarios"))
        {
            repoUsuario.ListarUsuarios();
        }
    }
}