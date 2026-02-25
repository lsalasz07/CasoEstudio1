using ElExitoS.A_.Services;
using ElExitoS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ElExitoS.A_.Controllers
{
    [Route("factura")]
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

        [HttpGet("detalle/{id}")]
        public IActionResult Detalle(int id)
        {
            var factura = _facturaService.ObtenerPorId(id);
            if (factura == null)
                return RedirectToAction("Index");

            return View(factura);
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
                    PrecioUnitario = producto.Precio,
                    Cantidad = cantidad
                });
            }

            if (!detalles.Any())
            {
                ModelState.AddModelError("", "Debe agregar al menos un producto con cantidad mayor a 0.");
                ViewBag.Productos = _productoService.ObtenerProductos();
                return View(new Factura());
            }

            var factura = new Factura
            {
                NombreCliente = nombreCliente,
                DetalleFacturas = detalles
            };

            _facturaService.AgregarFactura(factura);
            TempData["Exito"] = "Factura generada exitosamente.";
            return RedirectToAction("Index");
        }

        [HttpGet("descargar/{id}")]
        public FileResult Descargar(int id)
        {
            var factura = _facturaService.ObtenerPorId(id);

            if (factura == null)
                return File(Array.Empty<byte>(), "text/plain", "factura_no_encontrada.txt");

            var sb = new StringBuilder();
            sb.AppendLine("================================================");
            sb.AppendLine("       COMERCIALIZADORA EL ÉXITO S.A.");
            sb.AppendLine("================================================");
            sb.AppendLine($"Factura #:   {factura.Id}");
            sb.AppendLine($"Cliente:     {factura.NombreCliente}");
            sb.AppendLine($"Fecha:       {factura.Fecha:dd/MM/yyyy HH:mm}");
            sb.AppendLine("------------------------------------------------");
            sb.AppendLine($"{"Producto",-25} {"Cant",5} {"Precio",12} {"Total",12}");
            sb.AppendLine("------------------------------------------------");

            foreach (var detalle in factura.DetalleFacturas)
            {
                sb.AppendLine($"{detalle.NombreProducto,-25} {detalle.Cantidad,5} {detalle.PrecioUnitario,12:C} {detalle.Subtotal,12:C}");
            }

            sb.AppendLine("------------------------------------------------");
            sb.AppendLine($"{"Subtotal:",-35} {factura.Subtotal,12:C}");
            sb.AppendLine($"{"Impuesto (13%):",-35} {factura.Impuesto,12:C}");
            sb.AppendLine($"{"TOTAL:",-35} {factura.Total,12:C}");
            sb.AppendLine("================================================");

            var bytes = Encoding.UTF8.GetBytes(sb.ToString());
            return File(bytes, "text/plain", $"factura_{factura.Id}.txt");
        }
    }
}