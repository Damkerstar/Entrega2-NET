using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repoTramite, IUsuarioRepositorio repoUsuario, IServicioAutorizacion autorizacion, ServicioActualizacionEstado servicioActualizacion)
{
    public void Ejecutar(Tramite tramiteModificado, int idUsuario)
    {

        if(autorizacion.PoseeElPermiso(repoUsuario.BuscarUsuario(idUsuario), Permiso.TramiteModificacion))
        {
            
            repoTramite.BuscarTramite(tramiteModificado.ID);
            repoTramite.ModificarTramite(tramiteModificado);
            servicioActualizacion.Ejecutar(tramiteModificado.ExpedienteId, tramiteModificado.Etiqueta);
        }
        else
        {

            throw new AutorizacionException("No posee los permisos necesarios para realizar esa operación.");

        }
    }
}