using Microsoft.EntityFrameworkCore;
using Email.Models;
using Usuario.Models;
using Videojuegos.Models;

namespace WebApplication2.Context
{
    public class AplicacionContexto : DbContext
    {
        public AplicacionContexto
            (DbContextOptions<AplicacionContexto> options)
            : base(options) { }

        public DbSet<Usuarios> Usuario { get; set; }
        public DbSet<Emails> Email { get; set; }
        public DbSet<Videojuego> Videojuegos { get; set; }

    }
}
