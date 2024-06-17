namespace SGE.Aplicacion;

public class Usuario
{
    public int Id {get; set;}
    public string Nombre {get; set;} = "";
    public string Apellido {get; set;} = "";
    public string CorreoElectronico {get; set;} = "";
    public string Contrasena {set; private get;} = "";
    public List<String>? Permisos {get; set;}

    public Usuario(string n, string a, string c, string password, List<String>? p)
    {

        this.Nombre = n;
        this.Apellido = a;
        this.CorreoElectronico = c;
        this.Contrasena = password;
        this.Permisos = p;

    }
    
}