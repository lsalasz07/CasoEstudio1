using ElExitoS.Models;

namespace ElExitoS.A_.Services
{
    public class ProductoService : IProductoService
    {
        private static List<Producto> _productos = new()
        {
            new Producto { Id = 1, Nombre = "Laptop Hp", Precio =  850000},
            new Producto { Id = 2, Nombre = "Mouse Inalámbrico", Precio =  15000},
            new Producto { Id = 3, Nombre = "Teclado Mecánico", Precio =  45000},
            new Producto { Id = 4, Nombre = "Monitor", Precio =  120000},
            new Producto { Id = 5, Nombre = "Audífonos Bluetooth", Precio =  35000},
        };

        private static int _siguienteId = 6;

        public List<Producto> ObtenerTodos()
            => _productos.ToList();

        public Producto? ObtenerPorId(int id)
            => _productos.FirstOrDefault(p => p.Id == id);

        public void AgregarProducto(Producto producto)
        {
            producto.Id = _siguienteId++;
            _productos.Add(producto);
        }
    }
}
