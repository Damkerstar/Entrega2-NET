namespace SGE.Repositorios;
using SGE.Aplicacion;
using SQLitePCL;

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


    public List<Tramite> ListarTramite()
    {
        List<Tramite> tramites = new List<Tramite>();
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

    public Tramite BuscarUltimo(int idE)
    {
        Tramite? tramite;
        using (var context = new DatosContext())
        {
            var query = context.Expedientes.Where(e => e.ID == idE).SingleOrDefault();

            tramite = query.TramiteList.Last();
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
        using (var context = new DatosContext())
        {
            var query = context.Tramites.Where(t => t.IDTramite == idT).SingleOrDefault();
            
            if(query != null)
            {
                query.Etiqueta = (Etiqueta) Enum.Parse(typeof(Etiqueta), etiqueta);
                context.SaveChanges();
            }
        }
        if(query == null)
        {
            throw new RepositorioException("El tramite buscado no existe");
        }
    }
}
