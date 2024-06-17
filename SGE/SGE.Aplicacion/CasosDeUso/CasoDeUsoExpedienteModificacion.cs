namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio repoExpe, IUsuarioRepositorio repoUsuario, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(int eId, int idUsuario, string caratula, string estado)
    {
        if (autorizacion.PoseeElPermiso(repoUsuario.BuscarUsuario(idUsuario), Permiso.ExpedienteModificacion))
        {

            if(!string.IsNullOrWhiteSpace(caratula))
            {
                
                repoExpe.ModificarExpediente(eId, caratula, estado, idUsuario);
            }
            else
            {
                throw new ValidacionException("La carátula no puede estar vacía.\n");
            }
        }
        else
        {

            throw new AutorizacionException("No posee los permisos necesarios para realizar esa operación.");

        }
    }
}