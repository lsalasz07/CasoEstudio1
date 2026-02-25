using ElExitoS.Models;

namespace ElExitoS.A_.Services
{
    public class FacturaService : IFacturaService
    {
        private static List<Factura> _facturas = new();
        private static int _siguienteId = 1;

        public List<Factura> ObtenerFacturas()
            => _facturas.ToList();

        public Factura? ObtenerPorId(int id)
            => _facturas.FirstOrDefault(f => f.Id == id);

        public void AgregarFactura(Factura factura)
        {
            const decimal IVA = 0.13m;
            factura.Id = _siguienteId++;
            factura.Fecha = DateTime.Now;
            factura.Subtotal = factura.DetalleFacturas.Sum(d => d.Cantidad * d.PrecioUnitario);
            factura.Impuesto = Math.Round(factura.Subtotal * IVA, 2);
            factura.Total = factura.Subtotal + factura.Impuesto;
            _facturas.Add(factura);
        }
    }
}
