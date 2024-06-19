using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.CasosDeUso;
public class CasoDeUsoExpedienteConsultaTodos(IExpedienteRepositorio repoExpediente)
{
    public void Ejecutar()
    {
        repoExpediente.ListarExpedientes();
    }
}