using ElExitoS.Models;

namespace ElExitoS.A_.Services
{
    public class DetalleFacturaService : IDetalleFacturaService
    {
        private readonly IFacturaService _facturaService;

        public DetalleFacturaService(IFacturaService facturaService)
        {
            _facturaService = facturaService;
        }

        public List<DetalleFactura> ObtenerPorFactura(int facturaId)
        {
            var factura = _facturaService.ObtenerPorId(facturaId);
            return factura?.DetalleFacturas ?? new List<DetalleFactura>();
        }

        public void AgregarDetalle(int facturaId, DetalleFactura detalle)
        {
            var factura = _facturaService.ObtenerPorId(facturaId);
            if (factura == null) return;

            detalle.FacturaId = facturaId;
            factura.DetalleFacturas.Add(detalle);
        }
    }
}