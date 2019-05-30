﻿using System;
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
            return View();
        }

        public ActionResult Confecao()
        {
            return RedirectToAction("Index", "ConfecaoView");
        }

        public ActionResult Receita()
        {
            return RedirectToAction("Index", "ReceitasView");
        }

        public ActionResult About()
        {
            return View("Sobre");
        }
    }
}
