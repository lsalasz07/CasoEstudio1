using System.ComponentModel.DataAnnotations;

namespace ElExitoS.Models
{
    public class Factura
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NombreCliente { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        public decimal Subtotal { get; set; }

        [Required]
        public decimal Impuesto { get; set; }

        [Required]
        public decimal Total { get; set; }

        public List<DetalleFactura> DetalleFacturas { get; set; } = new();

    }
}