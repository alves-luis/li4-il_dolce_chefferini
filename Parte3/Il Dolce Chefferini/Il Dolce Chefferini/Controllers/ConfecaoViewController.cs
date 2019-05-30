using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Il_Dolce_Chefferini.Models;
using Microsoft.AspNetCore.Mvc;

namespace Il_Dolce_Chefferini.Controllers
{
    public class ConfecaoViewController : Controller 
    {
        public ActionResult Index(int receitaId)
        {
            return View();
        }

        public async Task<ActionResult> Next(int id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:5000/api/Confecao/" + id + "/proximo");
            var passo = await response.Content.ReadAsAsync<Passo>();
            return View(passo);
        }
    }
}
