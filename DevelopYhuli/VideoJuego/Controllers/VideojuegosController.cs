using Microsoft.AspNetCore.Mvc;
using WebApplication2.Context;
using Videojuegos.Models;

namespace Videojuegos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideojuegoController : ControllerBase
    {
    
        private readonly ILogger<VideojuegoController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;
        public VideojuegoController(
            ILogger<VideojuegoController> logger, 
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        //Create: Crear videojuego
        [Route("")]
        [HttpPost]
        public IActionResult Create([FromBody] Videojuego videojuego)
        {
            _aplicacionContexto.Videojuegos.Add(videojuego);
            _aplicacionContexto.SaveChanges();
            return Ok(videojuego);
        }
        //READ: Obtener lista de videojuegos
        [Route("")]
        [HttpGet]
        public IEnumerable<Videojuego> Get()
        {
            return _aplicacionContexto.Videojuegos.ToList();
        }

        //Update: Modificar videojeugoss
        [Route("videojuego")]
        [HttpPut]
        public IActionResult Update([FromBody] Videojuego videojuego)
        {
            _aplicacionContexto.Videojuegos.Update(videojuego);
            _aplicacionContexto.SaveChanges();
            return Ok(videojuego);
        }

        //Delete: Eliminar videojuego
        [Route("videojuego/{videojuegoId}")]
        [HttpDelete]
        public IActionResult Delete(int videojuegoId)
        {
            _aplicacionContexto.Videojuegos.Remove(
                _aplicacionContexto.Videojuegos.ToList()
                .Where(x => x.IdVideojuegos == videojuegoId)
                .FirstOrDefault());
            _aplicacionContexto.SaveChanges ();
            return Ok(videojuegoId);
        }
    }
}