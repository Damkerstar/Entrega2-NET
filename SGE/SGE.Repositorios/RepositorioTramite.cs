namespace SGE.Repositorios;
using SGE.Aplicacion;

public class RepositorioTramite : ITramiteRepositorio
{

    public void AgregarTramite(Tramite tramite)
    {
        
        DatosSqlite.Inicializar();
        
        using (var context = new DatosContext()) 
        {
            context.Add(tramite);
            context.SaveChanges();
        }

    }

    public List<Tramite> ListarTramite()
    {
        List<Tramite> tramites = new List<Tramite>();
        DatosSqlite.Inicializar();

        using (var context = new DatosContext())
        {
            foreach(Tramite tramite in context.Tramites)
            {
                tramites.Add(tramite);
            }
            
        }

        return tramites;
    }

    public void EliminarTramite(int idtramite)
    {

        DatosSqlite.Inicializar();

        using (var context = new DatosContext())
        {
            var tramiteBorrar = context.Tramites.Where(tramite => tramite.IDTramite == idtramite).SingleOrDefault();

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
        DatosSqlite.Inicializar();

        using (var context = new DatosContext())
        {
            EtiquetaTramite etiqueta = (EtiquetaTramite) Enum.Parse(typeof(EtiquetaTramite), etiq);
            
            foreach(Tramite tramite in context.Tramites)
            {
                if(tramite.Etiqueta == etiqueta)
                {
                    listaTramite.Add(tramite);
                }
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
        Tramite? tramite;
        DatosSqlite.Inicializar();

        using (var context = new DatosContext())
        {
            var query = context.Tramites.Where(t => t.IDTramite == idTramite).SingleOrDefault();

            tramite = query;
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
        DatosSqlite.Inicializar();

        using (var context = new DatosContext())
        {
            var query = context.Expedientes.Where(e => e.ID == idE).SingleOrDefault();

            if(query != null && query.TramiteList.Last() != null)
            {

                tramite = query.TramiteList.Last();

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

    public void ModificarTramite(int idT, string etiqueta)
    {

        Tramite? aux = null;
        DatosSqlite.Inicializar();

        using (var context = new DatosContext())
        {
            var query = context.Tramites.Where(t => t.IDTramite == idT).SingleOrDefault();
            
            if(query != null)
            {
                query.Etiqueta = (EtiquetaTramite) Enum.Parse(typeof(EtiquetaTramite), etiqueta);
                query.fechaYhoraModificacion = DateTime.Now;
                aux = query;
                context.SaveChanges();
            }

        }

        if(aux == null)
        {
            throw new RepositorioException("El tramite buscado no existe");
        }
    }
}
