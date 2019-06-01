using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using Il_Dolce_Chefferini.Dto;
using Il_Dolce_Chefferini.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Il_Dolce_Chefferini.Controllers
{
    public class UtilizadoresViewController : Controller
    {
        [HttpGet]
        public ActionResult Autenticar()
        {
            return View("Autenticar");
        }

        [HttpGet]
        public ActionResult Registar()
        {
            return View("Registar");
        }

        [HttpPost]
        public async Task<ActionResult> Autenticar([Bind] UtilizadorDto user)
        {
            var client = new HttpClient();
            var response = await client.PostAsync(new Uri("http://localhost:5001/api/Utilizadores/autenticar"),new StringContent(user.ToString()) 
                );
            var u = await response.Content.ReadAsAsync<Utilizador>();
            
            if (u == null)
                return View("Autenticar");
            
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Index()
        {
            return View("LoggedIndex");
        }
    }
}