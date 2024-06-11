namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repoExpediente, IServicioAutorizacion autorizacion)
{

    public void Ejecutar(int idExpediente, int idUsuario)
    {

        if(autorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteAlta))
        {

            // Deberia eliminar los expedientes y Tramites desde la base de datos sin necesidad de llamar al repoTramite
            repoExpediente.EliminarExpediente(idExpediente);

        }
        else
        {

            throw new AutorizacionException("No posee los permisos necesarios para realizar esa operación.");

        }

    }

}