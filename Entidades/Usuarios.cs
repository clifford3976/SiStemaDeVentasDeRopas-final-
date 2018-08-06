using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }

        public Usuarios()
        {
            UsuarioId = 0;
            Nombre = string.Empty;
            NombreUsuario = string.Empty;
            Contrasena = string.Empty;
        }
    }
}
