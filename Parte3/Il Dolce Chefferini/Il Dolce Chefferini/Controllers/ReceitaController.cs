using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Il_Dolce_Chefferini.Models;
using Microsoft.AspNetCore.Mvc;

namespace Il_Dolce_Chefferini.Controllers
{
    public class ReceitaController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:5000/api/Receitas");
            var receitas = await response.Content.ReadAsAsync<IEnumerable<Receita>>();
            return View(receitas);
        }
    }
}