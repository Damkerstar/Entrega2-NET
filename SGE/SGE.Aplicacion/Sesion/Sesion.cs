using SGE.Aplicacion;
using SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;
using System.Security.Cryptography;
using System.Text;

public class Sesion : ISesion
{
    
    public Usuario? sesionIniciada = null;

    public void CargarSesion(Usuario u)
    {
        this.sesionIniciada = u;
    }

    public Usuario? GetSesion()
    {
        return this.sesionIniciada;
    }

}