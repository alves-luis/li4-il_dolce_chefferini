using System;
using System.Linq;
using System.Threading.Tasks;
using Il_Dolce_Chefferini.Models;
using Microsoft.AspNetCore.Mvc;

namespace Il_Dolce_Chefferini.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DolceChefferiniController : ControllerBase
    {
        private readonly DolceChefferiniContext _context;

        public DolceChefferiniController(DolceChefferiniContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> IniciaConfecao([FromBody] Confecao c)
        {
            Console.WriteLine(c.id);
            if (_context.confecoes.Any(conf => conf.id == c.id))
                return Conflict();
            await _context.confecoes.AddAsync(c);
            return CreatedAtAction(nameof(GetById), new {id = c.id}, c);
        }

        [HttpGet]
        public async Task<ActionResult<Confecao>> GetById(int id)
        {
            return null;
        }
    }
}