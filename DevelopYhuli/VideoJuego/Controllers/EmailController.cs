using Microsoft.AspNetCore.Mvc;
using WebApplication2.Context;
using Email.Models;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Collections.Generic;

namespace Email.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly ILogger<EmailController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;

        public EmailController(ILogger<EmailController> logger, AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }

        // Create: Crear email
        [Route("")]
        [HttpPost]
        public IActionResult Create([FromBody] Emails emails)
        {
            _aplicacionContexto.Email.Add(emails);
            _aplicacionContexto.SaveChanges();
            return Ok(emails);
        }

        // READ: Obtener lista de emails
        [Route("")]
        [HttpGet]
        public IEnumerable<Emails> Get()
        {
            return _aplicacionContexto.Email.ToList();
        }

        // Update: Modificar email
        [Route("email")]
        [HttpPut]
        public IActionResult Update([FromBody] Emails emails)
        {
            _aplicacionContexto.Email.Update(emails);
            _aplicacionContexto.SaveChanges();
            return Ok(emails);
        }

        // Delete: Eliminar email
        [Route("email/{emailId}")]
        [HttpDelete]
        public IActionResult Delete(int emailId)
        {
            _aplicacionContexto.Email.Remove(
                _aplicacionContexto.Email
                .Where(x => x.IdEmail == emailId)
                .FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(emailId);
        }
    }
}
