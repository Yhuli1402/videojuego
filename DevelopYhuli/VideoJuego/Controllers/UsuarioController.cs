using Microsoft.AspNetCore.Mvc;
using WebApplication2.Context;
using Usuario.Models;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Collections.Generic;

namespace Usuario.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;

        public UsuarioController(ILogger<UsuarioController> logger, AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }

        // Create: Crear usuario
        [Route("")]
        [HttpPost]
        public IActionResult Create([FromBody] Usuarios usuarios)
        {
            _aplicacionContexto.Usuario.Add(usuarios);
            _aplicacionContexto.SaveChanges();
            return Ok(usuarios);
        }

        // READ: Obtener lista de usuarios
        [Route("")]
        [HttpGet]
        public IEnumerable<Usuarios> Get()
        {
            return _aplicacionContexto.Usuario.ToList();
        }

        // Update: Modificar usuarios
        [Route("usuario")]
        [HttpPut]
        public IActionResult Update([FromBody] Usuarios usuarios)
        {
            _aplicacionContexto.Usuario.Update(usuarios);
            _aplicacionContexto.SaveChanges();
            return Ok(usuarios);
        }

        // Delete: Eliminar usuarios
        [Route("usuario/{usuarioId}")]
        [HttpDelete]
        public IActionResult Delete(int usuarioId)
        {
            _aplicacionContexto.Usuario.Remove(
                _aplicacionContexto.Usuario
                .Where(x => x.IdUsuario == usuarioId)
                .FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(usuarioId);
        }
    }
}
