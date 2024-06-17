namespace SGE.Aplicacion;

public interface IExpedienteRepositorio
{
    void EscribirExpediente(Expediente e);
    List<Expediente> ListarExpedientes();
    void EliminarExpediente(int eID);
    void ModificarExpediente(int eId, string caratula, string estado, int idUsuario);
    Expediente BuscarExpedientePorId(int eId);
    void ModificarEstadoExpediente(int idE, EstadoExpediente estado);
}