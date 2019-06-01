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
        public async Task<ActionResult> Index(int receitaId)
        {
            var client = new HttpClient();
            var response = await client.PostAsync(new Uri("http://localhost:5000/api/Confecao/" + receitaId),null);
            var confecao = await response.Content.ReadAsAsync<Confecao>();
            return View(confecao);
        }

        public async Task<ActionResult> Next(int receitaId)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:5000/api/Confecao/" + receitaId + "/proximo");
            var passo = await response.Content.ReadAsAsync<Passo>();
            return View("Passo1",passo);
        }
    }
}
