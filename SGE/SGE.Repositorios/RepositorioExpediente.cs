namespace SGE.Repositorios;
using SGE.Aplicacion;

public class RepositorioExpediente : IExpedienteRepositorio //Modificar Interfaces
{  

    public void EscribirExpediente(Expediente e)
    {

        using (var context = new DatosContext())
        {
            context.Add(e);
            context.SaveChanges();
        }

    }
    
    public List<Expediente> ListarExpedientes()
    {

        List<Expediente> lista = new List<Expediente>();

        using (var context = new DatosContext())
        {
           
            foreach(Expediente t in context.Expedientes)
            {

                lista.Add(t);

            }
                
        }

        return lista;

    }

    public void EliminarExpediente(int eID)
    {

        Expediente? expedienteBorrar;

        using(var context = new DatosContext())
        {

            expedienteBorrar = context.Expedientes.Where(e => e.ID == eID).SingleOrDefault();    
        
            if(expedienteBorrar != null)
            {
                context.Remove(expedienteBorrar);
                context.SaveChanges();
            }

        }

        if(expedienteBorrar == null)
        {
            throw new RepositorioException("El expediente buscado no existe.");

        }

    }

    public void ModificarExpediente(int eId, string caratula, string estado, int idUsuario) //Actualizar casos de uso 8(
    {

        Expediente? expedienteModificar;

        using(var context = new DatosContext())
        {

            expedienteModificar = context.Expedientes.Where(e => e.ID == eId).SingleOrDefault();
        
            if(expedienteModificar != null)
            {

                //Funcionará?
                expedienteModificar.caratula = caratula;
                expedienteModificar.fechaYHoraActualizacion = DateTime.Now;
                expedienteModificar.usuarioID = idUsuario;
                expedienteModificar.Estado = (EstadoExpediente) Enum.Parse(typeof(EstadoExpediente), estado);

                //Lo averiguaremos en el próximo episodio de Dragon Ball Z Kai
                context.SaveChanges();

            }

        }  

        if(expedienteModificar == null)
        {
            throw new RepositorioException("El expediente buscado no existe.");
        }

    }

    public Expediente BuscarExpedientePorId(int eId)
    {

        Expediente? expedienteBusqueda;

        using(var context = new DatosContext())
        {

            expedienteBusqueda = context.Expedientes.Where(e => e.ID == eId).SingleOrDefault();

        }
        
        if(expedienteBusqueda == null) throw new RepositorioException("El expediente buscado no existe.");
        
        return expedienteBusqueda;

    }

    public void ModificarEstadoExpediente(int id, EstadoExpediente estado)
    {

        Expediente? e;

        using(var context = new DatosContext())
        {

            var query = context.Expedientes.Where(e => e.ID == id).SingleOrDefault();

            if(query != null)
            {

                query.Estado = estado;
                context.SaveChanges();

            }
            e = query;

        }

        if(e == null) throw new RepositorioException("El expediente buscado no existe.");

    }

}
