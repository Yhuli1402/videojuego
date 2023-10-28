using System.ComponentModel.DataAnnotations;

namespace Videojuegos.Models
{
    public class Videojuego
    {
        [Key]
        public int IdVideojuegos { get; set; }
        public string Nombre { get; set; }
        public string TipoDePago { get; set; }
        public bool EsGrupal { get; set; }
        public string Tipo { get; set; }
        public int IdUsuario { get; set; }
    }
}