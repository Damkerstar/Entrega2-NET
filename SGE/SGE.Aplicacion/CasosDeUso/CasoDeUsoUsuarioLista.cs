using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoUsuarioLista(IServicioAutorizacion autorizacion, IUsuarioRepositorio repoUsuario)
{
    public List<Usuario> Ejecutar(int ID)
    {
        Console.WriteLine("AAAh");
        if(autorizacion.PoseeElPermiso(repoUsuario.BuscarUsuario(ID), "ListarUsuarios"))
        {
            Console.WriteLine("Entre if");
            return repoUsuario.ListarUsuarios();
        }
        return repoUsuario.ListarUsuarios();
    }
}