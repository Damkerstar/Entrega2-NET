namespace SGE.Aplicacion;

public class ServicioAutorizacion : IServicioAutorizacion
{

    public bool PoseeElPermiso(Usuario user, Permiso permiso)
    {

        return user.Permiso.Any(permiso);

    }

}