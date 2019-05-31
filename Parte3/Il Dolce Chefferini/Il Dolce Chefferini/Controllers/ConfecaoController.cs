using System.Linq;
using System.Threading.Tasks;
using Il_Dolce_Chefferini.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpPost("{receitaId}")]
        public async Task<IActionResult> IniciaConfecao(int receitaId)
        {
            Confecao c = new Confecao(receitaId);
            _context.confecoes.Add(c);
            await _context.SaveChangesAsync();
            c = _context.confecoes
                .Where(conf => conf.id == c.id)
                .Include(conf => conf.receita)
                .Include(conf => conf.receita.passos)
                .First();
            return CreatedAtAction(nameof(GetById), new {receitaId}, c);
        }

        // retorna uma confecao dado um id
        [HttpGet("{id}/get")]
        public ActionResult<Confecao> GetById(int id)
        {
            var c = _context.confecoes
                .Include(conf => conf.receita)
                .Include(conf => conf.receita.passos)
                .First(e => e.id == id);
            if (c == null)
                return NoContent();       
            return c;
        }

        // retorna o próximo passo dado um id
        [HttpGet("{id}/proximo")]
        public ActionResult<Passo> GetProximoPasso(int id)
        {
            var c = _context.confecoes
                .Include(conf => conf.receita)
                .Include(conf => conf.receita.passos)
                .Include(conf => conf.tempoEmPasso)
                .First(e => e.id == id);
            
            if (c == null)
                return NoContent();
            
            var ret = c.GetProximoPasso();
            
            _context.confecoes.Update(c);
            _context.SaveChanges();

            return _context.passos.Where(p => p.Equals(ret))
                .Include("ingredientes.ingrediente")
                .First();
        }

    }
}