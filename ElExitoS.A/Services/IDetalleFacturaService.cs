using ElExitoS.Models;

namespace ElExitoS.A_.Services
{
    public interface IDetalleFacturaService
    {
        List<DetalleFactura> ObtenerPorFactura(int facturaId);
        void AgregarDetalle(int facturaId, DetalleFactura detalle);
    }
}