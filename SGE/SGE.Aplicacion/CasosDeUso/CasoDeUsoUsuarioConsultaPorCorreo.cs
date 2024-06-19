using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoUsuarioConsultaPorCorreo(IUsuarioRepositorio repoUsuario)
{
    public Usuario Ejecutar(string correo)
    {
        Usuario u = repoUsuario.DevolverPorCorreo(correo);

        if(u != null)
        {
            return u;
        }
        else
        {
            throw new UsuarioNoRegistradoException("El correo ingresado no se encuentra registado.");
        }
    }
}