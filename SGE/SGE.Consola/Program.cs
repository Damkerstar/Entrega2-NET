using SGE.Aplicacion;
using SGE.Repositorios;

class Program
{
    public static void Main(string[] args)
    {
        // Configurar dependencias
        /*IExpedienteRepositorio ExpedienteRepositorio = new RepositorioExpedienteTXT();
        ITramiteRepositorio TramiteRepositorio = new RepositorioTramiteTXT();
        ServicioActualizacionEstado ServicioActualizacion = new ServicioActualizacionEstado(ExpedienteRepositorio, new EspecificacionCambioEstado());

        // Casos de Uso Expediente
        var BajaExpediente = new CasoDeUsoExpedienteBaja(ExpedienteRepositorio, TramiteRepositorio, new ServicioAutorizacion());
        var AltaExpediente = new CasoDeUsoExpedienteAlta(ExpedienteRepositorio, new ExpedienteValidador(), new ServicioAutorizacion());
        var TodosExpedientes = new CasoDeUsoExpedienteConsultaTodos(ExpedienteRepositorio);
        var ExpedientesPorID = new CasoDeUsoExpedienteConsultaPorId(ExpedienteRepositorio, TramiteRepositorio);
        var ExpedienteModificacion = new CasoDeUsoExpedienteModificacion(ExpedienteRepositorio, new ServicioAutorizacion());

        // Casos de uso Tramite
        var BajaTramite = new CasoDeUsoTramiteBaja(TramiteRepositorio, new ServicioAutorizacion(), ServicioActualizacion);
        var AltaTramite = new CasoDeUsoTramiteAlta(TramiteRepositorio, new TramiteValidador(), new ServicioAutorizacion(), ServicioActualizacion);
        var TramitePorEtiqueta = new CasoDeUsoTramiteConsultaPorEtiqueta(TramiteRepositorio);
        var TramiteModificacion = new CasoDeUsoTramiteModificacion(TramiteRepositorio, new ServicioAutorizacion(), ServicioActualizacion);
        */
        try
        {
            /*AltaExpediente.Ejecutar(new Expediente("Carátula del Expediente", 1){}, 1);
            AltaExpediente.Ejecutar(new Expediente("Carátula del Expediente", 1){}, 1);

            AltaTramite.Ejecutar(new Tramite("Descripción del Tramite", 1, 1){}, 1);
            AltaTramite.Ejecutar(new Tramite("Descripción del Tramite", 1, 2){}, 1);

            ExpedientesPorID.Ejecutar(1);
            ExpedientesPorID.Ejecutar(2);
            
            TramiteModificacion.Ejecutar(1, "Pase_Estudio", 1);
            ExpedientesPorID.Ejecutar(1);
            
            
            AltaTramite.Ejecutar(new Tramite("Descripción del Tramite", 1, 1){}, 1);
            ExpedientesPorID.Ejecutar(1);

            AltaTramite.Ejecutar(new Tramite("Descripción del Tramite", 1, 2){}, 1);
            ExpedientesPorID.Ejecutar(2);
            BajaExpediente.Ejecutar(2, 1);

            TodosExpedientes.Ejecutar();
            ExpedientesPorID.Ejecutar(1);*/

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}