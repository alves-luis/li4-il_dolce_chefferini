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
            var receitas = await _context.receitas
                .Include(r => r.passos)
                .ToListAsync();

            return receitas;
        }

        // GET: api/Receita/id
        [HttpGet("{id}")]
        public ActionResult<Receita> GetReceita(int id)
        {
            var receita = _context.receitas
                
                .First(r => r.id == id);

            if (receita == null)
                return NotFound();

            return receita;
        }

        [HttpGet("{id}/passos")]
        public ActionResult<IEnumerable<Passo>> GetPassos(int id)
        {
            var passos = _context.passos
                .Where(p => p.receitaId == id).ToList();
            return passos;
        }
        
        // retorna uma lista com os ingredientes de cada receita
        [HttpGet("{id}/ingredientes")]
        public ActionResult<IEnumerable<IngredientePasso>> GetIngredientes(int id)
        {
            var ingredientes = _context.ingredientesPassos
                .Include(p => p.ingrediente)
                .Where(p => p.receitaId == id).ToList();
            return ingredientes;
        }
        
        [HttpGet("ingredientes")]
        public ActionResult<IEnumerable<Ingrediente>> GetIngredientes()
        {
            var ingredientes = _context.ingredientes.ToList();
            return ingredientes;
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