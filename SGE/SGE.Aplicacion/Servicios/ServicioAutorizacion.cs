namespace SGE.Aplicacion;

public class ServicioAutorizacion : IServicioAutorizacion
{

    public bool PoseeElPermiso(Usuario user, Permiso permiso)
    {
        
        List<String>? lista = user.Permisos ?? new List<String>();

        foreach(string s in lista)
        {

            Permiso p = (Permiso) Enum.Parse(typeof(Permiso), s);

            if(p == permiso) return true;

        }

        return false;

    }

}