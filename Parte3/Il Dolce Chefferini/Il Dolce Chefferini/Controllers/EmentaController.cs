using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Il_Dolce_Chefferini.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Il_Dolce_Chefferini.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmentaController : ControllerBase
    {
        private readonly DolceChefferiniContext _context;

        public EmentaController(DolceChefferiniContext context)
        {
            _context = context;
        }
        
        // adiciona uma nova refeicao
        [HttpPost("{utilizadorId}/{diaDaSemana}/{almoco}/{receitaId}")]
        public async Task<IActionResult> AdicionaRefeicao(int utilizadorId, string diaDaSemana, bool almoco,
            int receitaId)
        {
            Ementa e = new Ementa(utilizadorId,receitaId,diaDaSemana,almoco);
            if (_context.ementas.Any(em => em.Equals(e)))
                return Conflict();
            
            _context.ementas.Add(e);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEmenta), new
            {
                utilizadorId, diaDaSemana, almoco

            }, e);
        }

        // devolve a receita associada ao utilizador dada uma refeicao
        [HttpGet("{utilizadorId}/{diaDaSemana}/{almoco}")]
        public ActionResult<Receita> GetEmenta(int utilizadorId, string diaDaSemana, bool almoco)
        {
            var em = _context.ementas
                .Find(almoco,utilizadorId, diaDaSemana);

            if (em == null)
                return NoContent();
            
            var receita = _context.receitas.Find(em.receitaId);
            return Ok(receita);
        }

        [HttpGet("{utilizadorId}")]
        public ActionResult<IEnumerable<Ementa>> GetEmentas(int utilizadorId)
        {
            var em = _context.ementas.Include(e => e.receita)
                .Where(e => e.utilizadorId == utilizadorId);

            if (!em.Any())
                return NoContent();

            return Ok(em);
        }
    }
}