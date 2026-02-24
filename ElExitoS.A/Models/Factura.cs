using System.ComponentModel.DataAnnotations;

namespace ElExitoS.Models
{
    public class Factura
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es obligatorio")]
        [Display(Name = "Nombre del Cliente")]
        public string NombreCliente { get; set; } = string.Empty;

        public DateTime Fecha { get; set; } = DateTime.Now;

        public decimal Subtotal { get; set; }

        public decimal Impuesto { get; set; }

        public decimal Total { get; set; }

        public List<DetalleFactura> DetalleFacturas { get; set; } = new();

    }
}