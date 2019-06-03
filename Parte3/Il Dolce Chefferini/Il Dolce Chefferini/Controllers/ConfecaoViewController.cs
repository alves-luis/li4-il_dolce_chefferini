using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Il_Dolce_Chefferini.Dto;
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

            var dto = new ConfecaoDto(confecao);
            dto.pre = true;

            return View("PrePasso",dto);
        }


        public async Task<ActionResult> Help(int confecaoId, bool status)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:5000/api/Confecao/" + confecaoId + "/get");
            var confecao = await response.Content.ReadAsAsync<Confecao>();
            response = await client.PostAsync(new Uri("http://localhost:5000/api/Confecao/" + confecaoId + "/ajuda"), null);

            var dto = new ConfecaoDto(confecao);
            dto.pre = status;

            return View("Help", dto);
       }

        public async Task<ActionResult> ReturnPre(int confecaoId)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:5000/api/Confecao/" + confecaoId + "/get");
            var confecao = await response.Content.ReadAsAsync<Confecao>();
            var dto = new ConfecaoDto(confecao);
            dto.pre = true;

            return View("PrePasso", dto);
        }

        public async Task<ActionResult> ReturnPasso(int confecaoId)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:5000/api/Confecao/" + confecaoId + "/get");
            var confecao = await response.Content.ReadAsAsync<Confecao>();
            response = await client.PostAsync(new Uri("http://localhost:5000/api/Confecao/" + confecaoId + "/ajuda"), null);

            var dto = new ConfecaoDto(confecao);
            dto.pre = false;

            return View("Passo", dto);
        }


        public async Task<ActionResult> Inicia(int confecaoId)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:5000/api/Confecao/" + confecaoId + "/inicia");
            var confecao = await response.Content.ReadAsAsync<Confecao>();
           
            var dto = new ConfecaoDto(confecao);
            dto.pre = false;

            return View("Passo",dto);
        }

        public async Task<ActionResult> Termina(int confecaoId)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:5000/api/Confecao/" + confecaoId + "/finaliza");
            var confecao = await response.Content.ReadAsAsync<Confecao>();

            var dto = new ConfecaoDto(confecao);
            dto.pre = true;

            return View("PrePasso", dto);
        }

        public async Task<ActionResult> Avalia(int confecaoId)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:5000/api/Confecao/" + confecaoId + "/final");
            var confecao = await response.Content.ReadAsAsync<Confecao>();
            return RedirectToAction("Index", "AvaliacaoView",new {idConfecao=confecaoId});
        }
    }
}