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

            _context.avaliacoes.Add(e);
            await _context.SaveChangesAsync();
            return Ok(e);
        }

        // devolve a receita associada ao utilizador dada uma refeicao
        [HttpGet("{utilizadorId}/{diaDaSemana}/{almoco}")]
        public ActionResult<Receita> GetEmenta(int utilizadorId, string diaDaSemana, bool almoco)
        {
            var em = _context.ementas
                .Find(almoco, utilizadorId, diaDaSemana);

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