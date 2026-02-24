using ElExitoS.Models;

namespace ElExitoS.A_.Services
{
    public interface IProductoService
    {
        List<Producto> ObtenerDisponibles();
        Producto? ObtenerDetalle(int id);
        bool CrearProducto(Producto producto);
        string GuardarImagen(IFormFile? imagen);
    }
}
