namespace SGE.Repositorios;
using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;

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

    //Revisar implementación y uso (Listar y Buscar por ID)
    //Es posible que al haber variables privadas se deba crear un nuevo Constructor?
    //Implementado porque en la teoría se devuelven cosas de esta forma para no devolver
    //un valor original y que pueda causar problemas su modificación.
    //También revisé por varios lados y aparentemente es lo correcto, pero no estoy seguro el manejo de las variables privadas.
    private Expediente Clonar(Expediente e)
    {

        Expediente copia = new Expediente(e);
        
        return copia;
        //Se devuelve una copia para no devolver el dato original
    }
    
    public List<Expediente> ListarExpedientes()
    {

        List<Expediente> lista = new List<Expediente>();

        using (var context = new DatosContext())
        {
           
            foreach(Expediente t in context.Expedientes)
            {

                Expediente copia = this.Clonar(t);
                lista.Add(copia);

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

        Expediente? expedienteBusqueda = null;

        using(var context = new DatosContext())
        {
            
            var query = context.Expedientes.Where(e => e.ID == eId).SingleOrDefault();

            if(query != null) expedienteBusqueda = this.Clonar(query);

        }
        
        if(expedienteBusqueda == null) throw new RepositorioException("El expediente buscado no existe.");
        
        return expedienteBusqueda;

    }

    public void ModificarEstadoExpediente(int id, EstadoExpediente estado)
    {

        bool ok = false;
        
        using(var context = new DatosContext())
        {

            var query = context.Expedientes.Where(e => e.ID == id).SingleOrDefault();

            if(query != null)
            {

                query.Estado = estado;
                context.SaveChanges();
                ok = true;

            }

        }

        if(!ok) throw new RepositorioException("El expediente buscado no existe.");

    }

}
