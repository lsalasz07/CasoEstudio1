using ElExitoS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ElExitoS.Repositories
{
    public interface IProductoRepository
    {
        List<Producto> ObtenerTodas();
        List<Producto> ObtenerDisponibles();
        Producto? ObtenerPorId(int id);
        bool ExisteId(int id);
        void Agregar(Producto producto);
        void Actualizar(Producto producto);
        void Eliminar(int id);
    }
}