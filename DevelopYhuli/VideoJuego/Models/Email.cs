using System.ComponentModel.DataAnnotations;

namespace Email.Models
{
    public class Emails
    {
        [Key]
        public int IdEmail { get; set; }
        public string Email { get; set; }
        public int IdUsuario { get; set; }
    }
}