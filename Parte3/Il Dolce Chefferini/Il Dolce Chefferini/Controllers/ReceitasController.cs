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
    public class ReceitasController : ControllerBase
    {
        private readonly DolceChefferiniContext _context;

        public ReceitasController(DolceChefferiniContext context)
        {
            _context = context;
        }

        // GET: api/Receita
        // Retorna todas as receitas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receita>>> GetReceitas()
        {
            var receitas = await _context.receitas.ToListAsync();
            if (receitas.Count == 0)
            {
                Receita r = new Receita();
                receitas.Add(r);
                _context.receitas.Add(r);
                _context.SaveChangesAsync();
            }

            return receitas;
        }

        // GET: api/Receita/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Receita>> GetReceita(int id)
        {
            var receita = await _context.receitas.FindAsync(id);

            if (receita == null)
                return NotFound();

            return receita;
        }

        // POST: api/Receita
        [HttpPost]
        public async Task<ActionResult<Receita>> PostReceita(Receita r)
        {
            _context.receitas.Add(r);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReceita), new {r.id}, r);
        }

        // PUT: api/Receita/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceita(int id, Receita r)
        {
            if (id != r.id)
                return BadRequest();

            if (_context.receitas.Contains(r))
            {
                _context.Entry(r).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest();
            }


            return NoContent();
        }
    }
}