namespace SGE.Repositorios;
using SGE.Aplicacion;

public class EscuelaSqlite
{

    public static void Inicializar()
    {
        using var context = new UsuarioContext();
        if(context.Database.EnsureCreated())
        {

            Console.WriteLine("Se creó la base de datos (Usuarios)");
            context.SaveChanges();

        }
    }

}