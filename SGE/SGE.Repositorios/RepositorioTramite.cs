namespace SGE.Repositorios;
using SGE.Aplicacion;
using SQLitePCL;

public class RepositorioTramite : ITramiteRepositorio
{

    public void AgregarTramite(Tramite tramite)
    {
       using (var cotext = new DatosContext()) 
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
            foreach(Tramite tramite in context)
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

    public void EliminarCompleto(int idE)
    {
        List<Tramite> listaTramite = ListarTramite();
        List<Tramite> listaTramiteCopia = ListarTramite();
        bool listaModificada = false;
        
        foreach(Tramite t in listaTramite)
        {

            if(t.ExpedienteId == idE)
            {

                listaTramiteCopia.Remove(t);
                listaModificada = true;

            }

        }

        if(listaModificada)
        {
            SobrescribirListaTramites(listaTramiteCopia);
        }
    }

    public Tramite BuscarUltimo(int idE)
    {

        using (var context = new DatosContext())
        {
            var query = context.Expedientes.Where(e => e.ID == idE).SingleOrDefault();

            Tramite tramite = query.TramiteList.Last();
            
        }
        return tramite;
    }
    public void ModificarTramite(int idT, string etiqueta)
    {
        Tramite tramite;
        using (var context = new DatosContext())
        {
            var DBTramite = context.Tramites.Where(t => t.IDTramite == idT).SingleOrDefault();

            DBTramite.Etiqueta = etiqueta;
            context.SaveChanges();
        }
    }
}
