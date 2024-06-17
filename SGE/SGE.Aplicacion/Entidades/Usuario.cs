using System.Security.Cryptography;
using System.Text;

namespace SGE.Aplicacion;

public class Usuario
{
    public int Id { get; private set; }
    public string Nombre {get; set;} = "";
    public string Apellido {get; set;} = ""; 
    public string CorreoElectronico {get; set;} = "";
    public string Contrasena {set; private get;} = "";
    public List<String>? Permisos {get; set;} = new List<String>();

    public Usuario(string n, string a, string c, string password, List<String>? p)
    {

        this.Nombre = n;
        this.Apellido = a;
        this.CorreoElectronico = c;
        this.Contrasena = HashearClave(password);
        this.Permisos = p;

    }

    private string HashearClave(string password)
    {

        var newPassword = new System.Text.StringBuilder();

        using(var h = SHA256.Create()) //SHA256 es el método de Hash. el Create() método de clase, es como un New
        {

            byte[] arrayPassword = h.ComputeHash(Encoding.UTF8.GetBytes(password));
            //Arreglo de Bytes porque el algoritmo criptográfico opera a nivel de bytes
            //UTF8 por la longitud en bits de los caracteres

            foreach(byte b in arrayPassword)
            {
                newPassword.Append(b.ToString("x2"));
                //x2 convierte cada byte (8bits) en su versión hexadecimal
                //Ej b[0] = 11111111 -> newPassword[0] = FF
            }

        }

        return newPassword.ToString();

    }
    
}