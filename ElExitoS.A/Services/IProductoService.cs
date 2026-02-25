using ElExitoS.Models;

namespace ElExitoS.A_.Services
{
    public interface IProductoService
    {
        List<Producto> ObtenerProductos();
        Producto? ObtenerPorId(int id);
        void AgregarProducto(Producto producto);
    }
}
