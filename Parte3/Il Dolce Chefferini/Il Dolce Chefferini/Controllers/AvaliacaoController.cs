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
    public class AvaliacaoController : ControllerBase
    {
        private readonly DolceChefferiniContext _context;

        public AvaliacaoController(DolceChefferiniContext context)
        {
            _context = context;
        }

        // adiciona uma avaliação
        [HttpPost("{idConfecao}/{dificuldade}/{ajuda}/{satisfacao}")]
        public async Task<IActionResult> AdicionaAvaliacao(int idConfecao, int dificuldade, int? ajuda, int satisfacao)
        {
            Avaliacao e = new Avaliacao(idConfecao, dificuldade, ajuda, satisfacao);
            if (_context.avaliacoes.Any(em => em.Equals(e)))
                return Conflict();
            
            var c = _context.confecoes
                .Include(conf => conf.receita)
                .Include(conf => conf.receita.passos)
                .First(a => a.id == idConfecao);
            if (c == null)
                return NoContent();

            c.AvaliaConfecao(dificuldade, ajuda, satisfacao);
            _context.avaliacoes.Add(e);
            _context.confecoes.Update(c);
            
            await _context.SaveChangesAsync();
            return Ok(e);
        }

    }
}
