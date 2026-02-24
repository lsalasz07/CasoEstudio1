using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElExitoS.Models
{
    public class DetalleFactura
    {
        [ForeignKey(nameof(Producto))]
        public int ProductoId { get; set; }

        [ForeignKey(nameof(Factura))]
        public int FacturaId { get; set; }

        [Required]
        public string NombreProducto { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public decimal PrecioUnitario { get; set; }
    }
}