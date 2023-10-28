using System.ComponentModel.DataAnnotations;

namespace Usuario.Models
{
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public bool Genero { get; set; }
        public int Edad { get; set; }
    }
}