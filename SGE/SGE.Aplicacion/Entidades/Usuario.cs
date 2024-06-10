namespace SGE.Aplicacion;

public Usuario
{
    public int Id {get; set;}
    public string Nombre {get; set;}
    public string Apellido {get; set;}
    public string CorreoElectronico {get; set;}
    public string contraseña {set;}
    public List<Permiso> Permisos {get; set;}
    
}