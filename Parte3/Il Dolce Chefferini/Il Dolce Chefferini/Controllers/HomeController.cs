using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Il_Dolce_Chefferini.Models;
using Microsoft.AspNetCore.Mvc;
namespace Il_Dolce_Chefferini.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            Passo p = new Passo();
            ViewBag.Message = p;
            return View();
        }

        public ActionResult Fod()
        {
            return RedirectToAction("Index", "ConfecaoV");
        }

        public ActionResult Receita()
        {
            return RedirectToAction("Index", "Receita");
        }
    }
}
