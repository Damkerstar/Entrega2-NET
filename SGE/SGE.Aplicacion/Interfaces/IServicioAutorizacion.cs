namespace SGE.Aplicacion;

public interface IServicioAutorizacion
{

    bool PoseeElPermiso(Usuario user, Permiso permiso);

}