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
    public class ReceitaController : ControllerBase
    {
        private readonly ReceitaContext _context;

        public ReceitaController(ReceitaContext context)
        {
            _context = context;
            if (_context.Receitas.Count() == 0)
            {
                // creates a new receita if it's empty
                _context.Receitas.Add(new Receita
                    {
                        calorias = 20, criador = "Admin", descricao = "Receita gerada automaticamente",
                        grauDificuldade = 5,
                        hidratos = 20,
                        lipidos = 20, nome = "Receita Automática",
                        proteinas = 20, temperatura = new Temperatura()
                    }
                );
                _context.SaveChanges();
            }
        }
        
        // GET: api/Receita
        // Retorna todas as receitas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receita>>> GetReceitas()
        {
            return await _context.Receitas.ToListAsync();
        }
        
        // GET: api/Receita/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Receita>> GetReceita(int id)
        {
            var receita = await _context.Receitas.FindAsync(id);

            if (receita == null)
                return NotFound();
                
            return receita;
        }
        
        // POST: api/Receita
        [HttpPost]
        public async Task<ActionResult<Receita>> PostReceita(Receita r)
        {
            _context.Receitas.Add(r);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReceita), new { id = r.Id }, r);
        }
        
        // POST: api/Receita/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceita(int id, Receita r)
        {
            if (id != r.Id)
                return BadRequest();
            
            _context.Entry(r).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}