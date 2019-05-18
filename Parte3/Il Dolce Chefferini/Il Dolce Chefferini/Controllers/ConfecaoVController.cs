using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Il_Dolce_Chefferini.Models;
using Microsoft.AspNetCore.Mvc;

namespace Il_Dolce_Chefferini.Controllers
{
    public class ConfecaoVController : Controller 
    {
        public ActionResult Index()
        {
            return View("Views/Confecao/Passo.cshtml");
        }


    }
}