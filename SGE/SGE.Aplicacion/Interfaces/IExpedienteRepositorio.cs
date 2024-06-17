namespace SGE.Aplicacion;

public interface IExpedienteRepositorio
{
    void EscribirExpediente(Expediente e);
    void EliminarExpediente(int eID);
    void ModificarExpediente(Expediente e);
    List<Expediente> ListarExpedientes();
    Expediente BuscarExpedientePorId(int eId);
}