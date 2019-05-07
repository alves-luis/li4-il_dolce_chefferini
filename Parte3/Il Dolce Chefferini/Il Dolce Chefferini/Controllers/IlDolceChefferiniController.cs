using Il_Dolce_Chefferini.Models;
using Microsoft.AspNetCore.Mvc;

namespace Il_Dolce_Chefferini.Controllers
{
    public class IlDolceChefferiniController : ControllerBase
    {
        private readonly IlDolceChefferiniContext _context;

        public IlDolceChefferiniController(IlDolceChefferiniContext context)
        {
            _context = context;
        }
    }
}