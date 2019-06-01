using Il_Dolce_Chefferini.Dto;
using Il_Dolce_Chefferini.Models;
using Microsoft.AspNetCore.Mvc;

namespace Il_Dolce_Chefferini.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilizadoresController : ControllerBase
    {
        private readonly DolceChefferiniContext _context;

        public UtilizadoresController(DolceChefferiniContext context)
        {
            _context = context;
        }

        [HttpPost("autenticar")]
        public ActionResult<Utilizador> Autenticar([Bind] UtilizadorDto usDto)
        {
            var user = _context.Autenticar(usDto.email, usDto.password);

            if (user == null)
            {
                return BadRequest(new {message = "E-mail ou password errados"});
            }

            return Ok(user);
        }

        [HttpPost("registar")]
        public ActionResult<Utilizador> Registar([FromBody] UtilizadorDto uDto)
        {
            var u = _context.Registar(uDto.email, uDto.password);
            if (u == null)
                return BadRequest(new {message = "Utilizador já existente com esse e-mail"});

            return Ok(u);
        }
    }
}