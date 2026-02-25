using ElExitoS.Models;

namespace ElExitoS.A_.Services
{
    public interface IFacturaService
    {
        List<Factura> ObtenerFacturas();
        Factura? ObtenerPorId(int id);
        void Agregar(Factura factura);
    }
}
