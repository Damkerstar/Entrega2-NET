namespace SGE.Aplicacion;

public interface IServicioAutorizacion
{
    // La pregunta del millon
    bool PoseeElPermiso(Usuario user, Permiso permiso);

}