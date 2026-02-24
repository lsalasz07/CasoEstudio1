using ElExitoS.A_.Services;

namespace ElExitoS.A_.Services
{
    public class FileService : IFileService
    {
        public readonly IWebHostEnvironment _env;

        public FileService(IWebHostEnvironment env)
        {
            _env = env; 
        }

        public string ? GuardarImagen(IFormFile? archivo)
        {
            if (archivo == null || archivo.Length == 0)
                return null;

            var extension = Path.GetExtension(archivo.FileName);
            var nombreArchivo = Guid.NewGuid() + extension;

            var rutaCarpeta = Path.Combine(_env.WebRootPath, "images", "productos");
            Directory.CreateDirectory(rutaCarpeta);

            var rutaCompleta = Path.Combine(rutaCarpeta, nombreArchivo);

            using var stream = new FileStream(rutaCompleta, FileMode.Create);
            archivo.CopyTo(stream);

            return "/images/productos" + nombreArchivo;
        }
    }
}
