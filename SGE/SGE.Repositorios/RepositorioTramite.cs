namespace SGE.Repositorios;
using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;

public class RepositorioTramite : ITramiteRepositorio
{

    public void AgregarTramite(Tramite tramite)
    {
        
        using (var context = new DatosContext()) 
        {
            context.Add(tramite);
            context.SaveChanges();
        }

    }

    //Revisar implementación y uso (Listar, Buscar, Buscar último y buscar por etiqueta)
    //Es posible que al haber variables privadas se deba crear un nuevo Constructor?
    //Implementado porque en la teoría se devuelven cosas de esta forma para no devolver
    //un valor original y que pueda causar problemas su modificación.
    //También revisé por varios lados y aparentemente es lo correcto, pero no estoy seguro el manejo de las variables privadas.
    private Tramite Clonar(Tramite t)
    {

        Tramite copia = new Tramite(t);

        return copia;
        //Se devuelve una copia para no devolver el dato original
    }

    public List<Tramite> ListarTramite()
    {
        List<Tramite> tramites = new List<Tramite>();

        using (var context = new DatosContext())
        {
            foreach(Tramite tramite in context.Tramites)
            {
                Tramite copia = this.Clonar(tramite);
                tramites.Add(copia);
            }
            
        }

        return tramites;
    }

    public void EliminarTramite(int idtramite)
    {

        using (var context = new DatosContext())
        {
            var tramiteBorrar = context.Tramites.Where(tramite => tramite.ID == idtramite).SingleOrDefault();

            if(tramiteBorrar != null)
            {
                context.Remove(tramiteBorrar);
                context.SaveChanges();
            }
            else
            {
                throw new RepositorioException("El tramite buscado no existe");
            }
        }
    }

    public List<Tramite> BuscarPorEtiqueta(string etiq)
    {
        List<Tramite> listaTramite = new List<Tramite>();

        using (var context = new DatosContext())
        {

            EtiquetaTramite etiqueta = (EtiquetaTramite) Enum.Parse(typeof(EtiquetaTramite), etiq);
            var query = context.Tramites.Where(t => t.Etiqueta == etiqueta);
            //Revisar si esta query funciona ^
            foreach(Tramite tramite in query)
            {   
                Tramite copia = this.Clonar(tramite);
                listaTramite.Add(copia);
            }
        }

        if(listaTramite != null)
        {
            return listaTramite;
        }
        else
        {
            throw new RepositorioException("El tramite buscado no existe");
        }
    }

    public Tramite BuscarTramite(int idTramite)
    {
        Tramite? tramite = null;

        using (var context = new DatosContext())
        {
            var query = context.Tramites.Where(t => t.ID == idTramite).SingleOrDefault();

            if(query != null) tramite = this.Clonar(query);

        }

        if(tramite != null)
        {
            return tramite;
        }
        else
        {
            throw new RepositorioException("El tramite buscado no existe");
        }
    }

    public Tramite BuscarUltimo(int idE)
    {
        Tramite? tramite = null;

        using (var context = new DatosContext())
        {
            var query = context.Expedientes.Where(e => e.ID == idE).SingleOrDefault();

            if(query != null && query.TramiteList.Last() != null)
            {

                tramite = this.Clonar(query.TramiteList.Last());

            }
            
        }

        if(tramite != null)
        {
            return tramite;
        }
        else
        {
            throw new RepositorioException("El tramite buscado no existe");
        }

    }

    public void ModificarTramite(string descripcion, string etiqueta, int idTramite)
    {

        bool ok = false;

        using (var context = new DatosContext())
        {
            var query = context.Tramites.Where(t => t.ID == idTramite).SingleOrDefault();

            if(query != null)
            {
                query.Etiqueta = (EtiquetaTramite) Enum.Parse(typeof(EtiquetaTramite), etiqueta);
                query.Descripcion = descripcion;
                query.FechaYHoraModificacion = DateTime.Now;
                context.SaveChanges();
                ok = true;
            }

        }

        if(!ok)
        {
            throw new RepositorioException("El tramite buscado no existe");
        }

    }

    public Tramite? BuscarPorID(int idT)
    {
        Tramite? tramite = null;

        using (var context = new DatosContext())
        {
            var query = context.Tramites.Where(t => t.ID == idT).SingleOrDefault();

            if(query != null)
            {

                tramite = this.Clonar(query);

            }
            
        }

        return tramite;
    }
}
