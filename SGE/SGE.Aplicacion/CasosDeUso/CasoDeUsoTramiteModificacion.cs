using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repoTramite, IUsuarioRepositorio repoUsuario, IServicioAutorizacion autorizacion, ServicioActualizacionEstado servicioActualizacion)
{
    public void Ejecutar(int idTramite, string etiqueta, int idUsuario)
    {

        if(autorizacion.PoseeElPermiso(repoUsuario.BuscarUsuario(idUsuario), Permiso.TramiteModificacion))
        {
            
            repoTramite.ModificarTramite(idTramite, etiqueta);

            Tramite tramite = repoTramite.BuscarTramite(idTramite);
            
            servicioActualizacion.Ejecutar(tramite.ExpedienteId, tramite.Etiqueta);
        }
        else
        {

            throw new AutorizacionException("No posee los permisos necesarios para realizar esa operación.");

        }
    }
}