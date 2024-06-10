namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioBaja(IServicioAutorizacion autorizacion, IRepositorioUsuario usuario)
{
    public void Ejecutar(int idAdm,int Id)
    {

        if(autorizacion.PoseeElPermiso(usuario.BuscarId(IdAdm)))
        {
            usuario.EliminarUsuario(id);
        }
    }
}