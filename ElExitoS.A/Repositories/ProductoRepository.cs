using ElExitoS.Models;
using ElExitoS.A_.Data;
using System.Collections.Generic;
using System.Linq;

namespace ElExitoS.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly AppDbContext _context;

        public ProductoRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Producto> ObtenerTodas()
            => _context.Productos.OrderBy(m => m.Nombre).ToList();

        public List<Producto> ObtenerDisponibles()
            => _context.Productos
            .Where(m => !m.Comprar)
            .OrderBy(m => m.Nombre)
            .ToList();

        public Producto? ObtenerPorId(int id)
            => _context.Productos.Find(id);

        public bool ExisteId(int id)
            => _context.Productos.Any(m => m.Id == id);

        public void Agregar(Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
        }

        public void Actualizar(ProductoRepository producto)
        {
            _context.Productos.Update(producto);
            _context.SaveChanges():
        }

        public void Eliminar(int id)
        {
            var producto = ObtenerPorId(id);
            if (producto != null)
            {
                _context.Productos.remove(producto);
                _context.SaveChanges();
            }
        }
    }
}
