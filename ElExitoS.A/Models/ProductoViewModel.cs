using System.ComponentModel.DataAnnotations;

namespace ElExitoS.Models
{
    public class ProductoViewModel
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre del producto")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero")]
        [Display(Name = "Precio del producto")]
        public decimal Precio { get; set; }
    }
}
