namespace SGE.Aplicacion;
public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio repoExpediente)
{
    public void Ejecutar(int idE)
    {
        repoExpediente.BuscarExpedientePorId(idE);
    }
}