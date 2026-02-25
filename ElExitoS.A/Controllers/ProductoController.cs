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
            var productos = _productoService.ObtenerProductos();
            return View(productos);
        }

        [HttpGet("agregar")]
        public IActionResult Agregar()
        {
            return View(new Producto());
        }

        [HttpPost("agregar")]
        public IActionResult Agregar(Producto producto)
        {
            if (!ModelState.IsValid)
                return View(producto);

            _productoService.AgregarProducto(producto);
            TempData["Exito"] = "Producto agregado exitosamente.";
            return RedirectToAction("Index");
        }
    }
}
