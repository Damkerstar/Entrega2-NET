using SGE.Aplicacion.Entidades;

public interface ISesion
{
    void CargarSesion(Usuario u);
    Usuario? GetSesion();
}