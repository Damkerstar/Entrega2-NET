namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repoExpediente, IUsuarioRepositorio repoUsuario, IServicioAutorizacion autorizacion)
{

    public void Ejecutar(int idExpediente, int idUsuario)
    {

        if(autorizacion.PoseeElPermiso(repoUsuario.BuscarUsuario(idUsuario), Permiso.ExpedienteAlta))
        {

            repoExpediente.EliminarExpediente(idExpediente);

        }
        else
        {

            throw new AutorizacionException("No posee los permisos necesarios para realizar esa operación.");

        }

    }

}