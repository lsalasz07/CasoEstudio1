using ElExitoS.A_.Services;
using ElExitoS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ElExitoS.A_.Controllers
{
    public class FacturaController : Controller
    {
        private readonly IFacturaService _facturaService;
        private readonly IProductoService _productoService;

        public FacturaController(IFacturaService facturaService, IProductoService productoService)
        {
            _facturaService = facturaService;
            _productoService = productoService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var facturas = _facturaService.ObtenerFacturas();
            return View(facturas);
        }

        [HttpGet("generar")]
        public IActionResult Generar()
        {
            ViewBag.Productos = _productoService.ObtenerProductos();
            return View(new Factura());
        }

        [HttpPost("generar")]
        public IActionResult Generar(string nombreCliente, List<int> productoIds, List<int> cantidades)
        {
            if (string.IsNullOrWhiteSpace(nombreCliente))
            {
                ModelState.AddModelError("", "El nombre del cliente es obligatorio.");
                ViewBag.Productos = _productoService.ObtenerProductos();
                return View(new Factura());
            }
            var detalles = new List<DetalleFactura>();
            for (int i = 0; i < productoIds.Count; i++)
            {
                var producto = _productoService.ObtenerPorId(productoIds[i]);
                if (producto == null) continue;
                int cantidad = cantidades.Count > i ? cantidades[i] : 0;
                if (cantidad <= 0) continue;
                detalles.Add(new DetalleFactura
                {
                    ProductoId = producto.Id,
                    NombreProducto = producto.Nombre,
                    Cantidad = cantidad,
                    PrecioUnitario = producto.Precio
                });
            }
            if (detalles.Count == 0)
            {
                ModelState.AddModelError("", "Debe seleccionar al menos un producto con cantidad válida.");
                ViewBag.Productos = _productoService.ObtenerProductos();
                return View(new Factura());
            }
            var factura = new Factura
            {
                NombreCliente = nombreCliente,
                Detalles = detalles
            };
            _facturaService.GuardarFactura(factura);
            return RedirectToAction("Index");
        }
    }
}
