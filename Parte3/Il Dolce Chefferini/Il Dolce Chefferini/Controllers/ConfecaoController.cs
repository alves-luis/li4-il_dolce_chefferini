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
        [HttpPost]
        public async Task<IActionResult> IniciaConfecao([FromBody] Confecao c)
        {
            _context.confecoes.Add(c);
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

        // retorna o próximo passo dado um id
        [HttpGet("{id}/proximo")]
        public ActionResult<Passo> GetProximoPasso(int id)
        {
            var confecao = _context.confecoes
                .Include(conf => conf.receita)
                .Include(temp => temp.tempoEmPasso)
                .Where(conf => conf.id == id)
                .First();
            if (confecao == null)
                return NoContent();
            var ret = confecao.GetProximoPasso();

            return ret;
        }

    }
}