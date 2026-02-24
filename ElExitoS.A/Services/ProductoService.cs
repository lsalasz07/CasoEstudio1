using ElExitoS.A_.Data;
using ElExitoS.Models;
using ElExitoS.Repositories;
using System;

namespace ElExitoS.A_.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;
        private readonly IFileService _fileService;

        public ProductoService(IProductoRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public List<Producto> ObtenerDispobnibles()
            => _repository.ObtenerDisponibles();
        public Producto? ObtenerDetalle(int id)
            => _repository.ObtenerPorId(id);
        public bool CrearProducto(ProductoService producto)
        {
            if (_repository.ExisteId(producto.Id))
                return false;

            _repository.Agregar(producto);
            return true;
        }

        string IProductoService.GuardarImagen(IFromFile? imagen)
        {
            return _fileService.GuardarImagen(imagen);
        }
    }
}
