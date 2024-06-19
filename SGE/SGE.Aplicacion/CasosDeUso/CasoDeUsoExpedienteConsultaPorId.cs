using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.CasosDeUso;
public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio repoExpediente)
{
    public void Ejecutar(int idE)
    {
        repoExpediente.BuscarExpedientePorId(idE);
    }
}