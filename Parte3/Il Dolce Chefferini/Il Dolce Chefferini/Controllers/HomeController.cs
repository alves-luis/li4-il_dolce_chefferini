using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace Il_Dolce_Chefferini.Controllers
{
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            return View("../Confecao/Passo");
        }
    }
}
