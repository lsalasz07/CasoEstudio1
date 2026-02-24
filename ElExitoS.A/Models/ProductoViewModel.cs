namespace ElExitoS.Models
{
    public class ProductoViewModel
    {
        public string Nombre { get; set; }
        public int Precio { get; set; }

        public IFormFile? Imagen { get; set; }
    }
}
