namespace SGE.Aplicacion;
using SGE.Aplicacion.Entidades;
public class TramiteValidador
{
    public bool ValidarTramite(Tramite tramite, out string msg)
    {

        msg = "";

        if(string.IsNullOrWhiteSpace(tramite.Descripcion))
        {
            msg = "La descripcion no puede estar vacía.\n";
        }
        
        if(tramite.IdUsuario <= 0)
        {
            msg += "El ID de usuario debe que ser mayor que 0.\n";
        }

        return (msg == "");

    }
}