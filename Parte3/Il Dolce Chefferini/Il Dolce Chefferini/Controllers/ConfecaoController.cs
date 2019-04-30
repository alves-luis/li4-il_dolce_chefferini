using System;
using System.Threading.Tasks;
using Il_Dolce_Chefferini.Models;
using Il_Dolce_Chefferini.shared;
using Microsoft.AspNetCore.Mvc;

namespace Il_Dolce_Chefferini.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfecaoController : ControllerBase
    {
        private readonly UtilizadorHandling _userContext;
        private readonly ReceitaContext _receitaContext;

        public ConfecaoController(UtilizadorContext uContext, ReceitaContext rContext)
        {
            _userContext = new UtilizadorHandling(uContext);
            _receitaContext = rContext;
        }

        // PUT: api/confecao/utilizador/id
        [HttpPost("/{c.userId}/{c.id}")]
        public ActionResult<Confecao> Inicia(int userId)
        {
            var c = new Confecao(userId,new Receita());
            bool success = _userContext.IniciarConfecao(c);
            if (!success)
                return Conflict();
            return CreatedAtAction(nameof(Inicia), new {c.userId, c.id}, c);
        }
    }
}