using Il_Dolce_Chefferini.Models;
using Il_Dolce_Chefferini.shared;
using Microsoft.AspNetCore.Mvc;

namespace Il_Dolce_Chefferini.Controllers
{
    [Route("api/[controller]")]
    public class UtilizadorController : ControllerBase
    {
        private readonly UtilizadorHandling utilizadorHandling;

        public UtilizadorController(UtilizadorContext context)
        {
            utilizadorHandling = new UtilizadorHandling(context);
        }
    }
}