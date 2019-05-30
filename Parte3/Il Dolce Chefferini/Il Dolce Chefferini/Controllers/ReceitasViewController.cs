using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Il_Dolce_Chefferini.Models;
using Microsoft.AspNetCore.Mvc;

namespace Il_Dolce_Chefferini.Controllers
{
    public class ReceitasViewController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:5000/api/Receitas");
            var receitas = await response.Content.ReadAsAsync<IEnumerable<Receita>>();
            return View(receitas);
        }

        public async Task<ActionResult> Receita(int id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:5000/api/Receitas/" + id);
            var receita = await response.Content.ReadAsAsync<Receita>();
            return View(receita);
        }

        public async Task<ActionResult> Ingredientes(int id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:5000/api/Receitas/" + id + "/ingredientes");
            var ingredientes = await response.Content.ReadAsAsync<IEnumerable<IngredientePasso>>();

            return View(ingredientes);
        }
    }
}