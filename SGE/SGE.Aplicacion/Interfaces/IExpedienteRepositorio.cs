namespace SGE.Aplicacion;

public interface IExpedienteRepositorio
{
    void EscribirExpediente(Expediente e);
    void EliminarExpediente(int eID);
    void ModificarExpediente(Expediente e);
    Expediente BuscarExpedientePorId(int eId);
}