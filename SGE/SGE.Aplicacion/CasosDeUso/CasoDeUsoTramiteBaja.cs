namespace SGE.Aplicacion;
public class CasoDeUsoTramiteBaja(ITramiteRepositorio repoTramite, IUsuarioRepositorio repoUsuario, IServicioAutorizacion autorizacion, ServicioActualizacionEstado servicioActualizacion){
    public void Ejecutar(int idTramite, int idUsuario)
    {

        

        if(autorizacion.PoseeElPermiso(repoUsuario.BuscarUsuario(idUsuario), Permiso.TramiteBaja))
        {
            Tramite tramite = repoTramite.BuscarTramite(idTramite);
            repoTramite.EliminarTramite(idTramite);
            
            servicioActualizacion.Ejecutar(tramite.ExpedienteId, tramite.Etiqueta);
        }
        else
        {

            throw new AutorizacionException("No posee los permisos necesarios para realizar esa operación.");

        }

    }
}