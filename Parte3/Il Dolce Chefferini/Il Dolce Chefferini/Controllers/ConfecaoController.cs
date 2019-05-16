using System.Linq;
using System.Threading.Tasks;
using Il_Dolce_Chefferini.Models;
using Microsoft.AspNetCore.Mvc;

namespace Il_Dolce_Chefferini.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfecaoController : ControllerBase
    {
        private readonly DolceChefferiniContext _context;

        public ConfecaoController(DolceChefferiniContext context)
        {
            _context = context;
        }

        // inicia uma nova confeção
        [HttpPost]
        public async Task<IActionResult> IniciaConfecao([FromBody] Confecao c)
        {
            if (_context.confecoes.Any(conf => conf.id == c.id))
                return Conflict();
            await _context.confecoes.AddAsync(c);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {c.id}, c);
        }

        // retorna uma confecao dado um id
        [HttpGet("{id}")]
        public async Task<ActionResult<Confecao>> GetById(int id)
        {
            var c = await _context.confecoes.FindAsync(id);
            if (c == null)
                return NoContent();       
            return c;
        }
    }
}