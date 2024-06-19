using SGE.Aplicacion;
namespace SGE.Aplicacion.Entidades;

public class Tramite
{

    public int ExpedienteId {get; set;}
    public int IDTramite { private set; get; }
    private EtiquetaTramite _etiqueta = EtiquetaTramite.Escrito_Presentado;
    public EtiquetaTramite Etiqueta
    {
        get => _etiqueta;
        set => _etiqueta = value;
    }
    public string? Descripcion;
    public DateTime FechaYHoraCreacion {get;set;} = DateTime.Now;
    public DateTime FechaYHoraModificacion {get;set;} = DateTime.Now;
    public int IdUsuario {get;set;}


    public Tramite()
    {

    }

    public Tramite(string descripcion, int idUsuario, int expedienteId) 
    {

        this.Descripcion = descripcion;
        this.FechaYHoraModificacion = FechaYHoraCreacion;
        this.IdUsuario = idUsuario;
        this.ExpedienteId = expedienteId;

    }

    public Tramite(Tramite t)
    {

        this.ExpedienteId = t.ExpedienteId;
        this.IDTramite = t.IDTramite;
        this.Etiqueta = t.Etiqueta;
        this.Descripcion = t.Descripcion;
        this.FechaYHoraCreacion = t.FechaYHoraCreacion;
        this.FechaYHoraModificacion = t.FechaYHoraModificacion;
        this.IdUsuario = t.IdUsuario;

    }

    public override string ToString()
    {
        return $"""
        ID tramite: {IDTramite}
           ID expediente: {ExpedienteId}
           ID usuario: {IdUsuario}
           Etiqueta: {Etiqueta}
           Descripción: {Descripcion}
           Fecha y hora de:
             creacion: {FechaYHoraCreacion}
             modificacion: {FechaYHoraModificacion}
        """ + "\n";
    }

}