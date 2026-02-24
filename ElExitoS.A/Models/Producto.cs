using System.ComponentModel.DataAnnotations;

namespace ElExitoS.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre del Producto")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero")]
        [Display(Name = "Precio del Producto")]
        public decimal Precio { get; set; }
    }
}