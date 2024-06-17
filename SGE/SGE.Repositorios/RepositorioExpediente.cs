namespace SGE.Repositorios;
using SGE.Aplicacion;

public class RepositorioExpedienteTXT : IExpedienteRepositorio //Modificar Interfaces
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

    public void ModificarExpediente(Expediente exp) //Actualizar casos de uso 8(
    {

        Expediente? expedienteModificar;

        using(var context = new DatosContext())
        {

            expedienteModificar = context.Expedientes.Where(e => e.ID == exp.ID).SingleOrDefault();
        
            if(expedienteModificar != null)
            {
                
                //Funcionará?
                expedienteModificar.caratula = exp.caratula;
                expedienteModificar.fechaYHoraActualizacion = exp.fechaYHoraActualizacion;
                expedienteModificar.usuarioID = exp.usuarioID;
                expedienteModificar.Estado = exp.Estado;

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

}
