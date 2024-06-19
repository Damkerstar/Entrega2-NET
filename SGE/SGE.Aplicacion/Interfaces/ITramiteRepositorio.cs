using SGE.Aplicacion;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.Interfaces;

public interface ITramiteRepositorio
{
    void AgregarTramite(Tramite Tramite);
    void EliminarTramite(int idTramite);
    Tramite BuscarUltimo(int idExpediente);
    Tramite BuscarTramite(int idTramite);
    List<Tramite> BuscarPorEtiqueta(string etiqueta);
    List<Tramite> ListarTramite();
    void ModificarTramite(int idT, string etiqueta);
    Tramite BuscarPorID(int idT);
}