namespace SGE.Repositorios;
using SGE.Aplicacion;
using SQLitePCL;

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

    private List<Expediente> ListarExpedientes()
    {
        return Metodo().ToList();
    }
    private IEnumerable<Expediente> Metodo()
    {
        using (var context = new DatosContext())
        {
           
            foreach(Expediente t in context.Expedientes)
            {

                yield return t;

            }
                
        }
    }

    public void EliminarExpediente(int eID)
    {

        using(var context = new DatosContext())
        {

            var expedienteBorrar = context.Expedientes.Where(e => e.ID == eID).SingleOrDefault();
    
        
            if(expedienteBorrar != null)
            {
                context.Remove(expedienteBorrar);
                context.SaveChanges();
            }
            else
            {
                throw new RepositorioException("El expediente buscado no existe.");
            }

        }

    }

    public void ModificarExpediente(Expediente exp) //Actualizar casos de uso 8(
    {

        using(var context = new DatosContext())
        {

            var expedienteModificar = context.Expedientes.Where(e => e.ID == exp.ID).SingleOrDefault();
    
        
            if(expedienteModificar != null)
            {
                
                expedienteModificar = exp;
                context.SaveChanges();

            }
            else
            {
                throw new RepositorioException("El expediente buscado no existe.");
            }

        }  

    }

    public Expediente BuscarExpedientePorId(int eId)
    {

        using(var context = new DatosContext())
        {

            var expedienteBusqueda = context.Expedientes.Where(e => e.ID == eId).SingleOrDefault();

        
            if(expedienteBusqueda != null)
            {
                
                return expedienteBusqueda;
                //Se hace el close con el using al hacer return?
            }
            else
            {
                throw new RepositorioException("El expediente buscado no existe.");
            }

        }

    }

}
