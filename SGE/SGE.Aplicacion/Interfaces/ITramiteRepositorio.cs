namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    void AgregarTramite(Tramite Tramite);
    void EliminarTramite(int idTramite);
    Tramite BuscarUltimo(int idExpediente);
    List<Tramite> ListarPorExpediente(int idExpediente);
    void ModificarTramite(Tramite t, string etiqueta);
}