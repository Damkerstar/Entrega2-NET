using SGE.Aplicacion;
using SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;
using System.Security.Cryptography;
using System.Text;

class Sesion : ISesion
{
    
    Usuario? sesionIniciada;

    public bool ValidarSesion(Usuario u)
    {

        CargarSesion(u);
        Usuario? aux;

        using(var context = new DatosContext())
        {
            aux = context.Usuarios.Where(i => i.CorreoElectronico == u.CorreoElectronico).SingleOrDefault();
            Console.WriteLine(aux == null);
        }

        if((aux != null ) && (this.sesionIniciada.CorreoElectronico == aux.CorreoElectronico) && (this.sesionIniciada.Contrasena == aux.Contrasena))
        {
            Console.WriteLine("test");
            this.sesionIniciada.Nombre = aux.Nombre;
            this.sesionIniciada.Apellido = aux.Apellido;
            this.sesionIniciada.Permisos = new List<String?>(aux.Permisos);
            return true;
        }
        
        return false;

    }

    private void CargarSesion(Usuario u)
    {
        
        sesionIniciada = new Usuario
        {
            CorreoElectronico = u.CorreoElectronico,
            Contrasena = u.Contrasena
        };
    }

    public bool Registro(Usuario u)
    {

        Usuario? user;

        using(var context = new DatosContext())
        {
            user = context.Usuarios.Where(i => i.CorreoElectronico == u.CorreoElectronico).SingleOrDefault();
        }

        if(user == null)
        {
            return false;
        }
        else
        {
            u.Contrasena = this.HashearClave(u.Contrasena);
            CasoDeUsoUsuarioAlta.Ejecutar(u);
            return true;
        }

    }

    private string HashearClave(string password)
    {

        var newPassword = new System.Text.StringBuilder();

        using(var h = SHA256.Create())
        {
            byte[] arrayPassword = h.ComputeHash(Encoding.UTF8.GetBytes(password));

            foreach(byte b in arrayPassword)
            {
                newPassword.Append(b.ToString("x2"));
            }
        }

        return newPassword.ToString();

    }

}