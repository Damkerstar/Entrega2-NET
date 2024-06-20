namespace SGE.Aplicacion;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

public class ServicioAutorizacion : IServicioAutorizacion
{

    public bool PoseeElPermiso(Usuario user, Permiso permiso)
    {
        
        List<Permiso>? lista = user.Permisos ?? new List<Permiso>();

        foreach(Permiso s in lista)
        {
            if(s == permiso) return true;
        }

        return false;

    }

}