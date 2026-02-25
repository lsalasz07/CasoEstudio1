using ElExitoS.A_.Services;
using ElExitoS.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElExitoS.A_.Controllers
{
    [Route("detalle-factura")]
    public class DetalleFacturaController : Controller
    {
        private readonly IDetalleFacturaService _detalleFacturaService;
        private readonly IFacturaService _facturaService;

        public DetalleFacturaController(IDetalleFacturaService detalleFacturaService, IFacturaService facturaService)
        {
            _detalleFacturaService = detalleFacturaService;
            _facturaService = facturaService;
        }

        [HttpGet("{facturaId}")]
        public IActionResult Index(int facturaId)
        {
            var factura = _facturaService.ObtenerPorId(facturaId);
            if (factura == null)
                return RedirectToAction("Index", "Factura");

            var detalles = _detalleFacturaService.ObtenerPorFactura(facturaId);
            ViewBag.Factura = factura;
            return View(detalles);
        }
    }
}