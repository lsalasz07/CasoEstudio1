using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElExitoS.Models
{
    public class DetalleFactura
    {
        public int ProductoId { get; set; }

        public int FacturaId { get; set; }

        public string NombreProducto { get; set; } = string.Empty;

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Subtotal => Cantidad * PrecioUnitario;
    }
}