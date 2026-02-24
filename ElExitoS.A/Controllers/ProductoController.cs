using ElExitoS.A_.Services;
using ElExitoS.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElExitoS.A_.Controllers
{
    [Route ("producto")]
    public class ProductoController : Controller
    {
        private readonly IProductoService _productoService;
        
        public ProductoController (IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var productos = _productoService.ObtenerDisponibles();
            return View(productos);
        }

        [HttpGet("detalle/{id:int}")]
        public IActionResult Detalle(int id)
        {
            var producto = _productoService.ObtenerDetalle(id);
            if (producto == null)
                return NotFound();

            return View(producto);
        }

        [HttpGet("crear")]
        public IActionResult Crear()
        {
            return View(new ProductoViewModel());
        }

        [HttpPost("crear")]
        public IActionResult Crear(ProductoViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var producto = new Producto
            {
                Nombre = model.Nombre,
                Precio = model.Precio,
                ImagenUrl = _productoService.GuardarImagen(model.Imagen)
            };

            _productoService.CrearProducto(producto);

            return RedirectToAction("Index");
        }
    }
}
