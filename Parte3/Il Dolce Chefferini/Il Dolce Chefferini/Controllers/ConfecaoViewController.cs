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
            return View("PrePasso",confecao);
        }


        public async Task<ActionResult> Help(int confecaoId)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:5000/api/Confecao/" + confecaoId + "/get");
            var confecao = await response.Content.ReadAsAsync<Confecao>();
            return View("Help", confecao);
       }


        public async Task<ActionResult> Inicia(int confecaoId)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:5000/api/Confecao/" + confecaoId + "/inicia");
            var confecao = await response.Content.ReadAsAsync<Confecao>();
            return View("Passo",confecao);
        }

        public async Task<ActionResult> Termina(int confecaoId)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:5000/api/Confecao/" + confecaoId + "/finaliza");
            var confecao = await response.Content.ReadAsAsync<Confecao>();
            return View("PrePasso", confecao);
        }

        public async Task<ActionResult> Avalia(int confecaoId)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:5000/api/Confecao/" + confecaoId + "/final");
            var confecao = await response.Content.ReadAsAsync<Confecao>();
            return View("Avaliacao", confecao);
        }
    }
}