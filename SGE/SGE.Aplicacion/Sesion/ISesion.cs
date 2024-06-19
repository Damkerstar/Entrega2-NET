using SGE.Aplicacion.Entidades;

public interface ISesion
{
    bool ValidarSesion(Usuario u);
    bool Registro(Usuario u);
}