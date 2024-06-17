namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    void AgregarTramite(Tramite Tramite);
    void EliminarTramite(int idTramite);
    Tramite BuscarUltimo(int idExpediente);
    List<Tramite> ListarTramite();
    void ModificarTramite(int idT, string etiqueta);
}