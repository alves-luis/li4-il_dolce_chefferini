using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Il_Dolce_Chefferini.Dto;
using Il_Dolce_Chefferini.Models;
using Microsoft.AspNetCore.Mvc;

namespace Il_Dolce_Chefferini.Controllers
{
    public class AvaliacaoViewController : Controller
    {
        public async Task<ActionResult> Index(int idConfecao)
        {
            Console.WriteLine(idConfecao + "\n");
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:5000/api/Confecao/" + idConfecao + "/get");
            var confecao = await response.Content.ReadAsAsync<Confecao>();
           
           var dto = new AvaliacaoDto(idConfecao);
            dto.usouAjuda = confecao.usouAjuda;
            return View(dto);
        }

        public async Task<ActionResult> AvaliaDif(int idConfecao, int dif, int? ajuda, int? satis, bool usouAjuda)
        {

            var dto = new AvaliacaoDto(idConfecao);
            dto.dificuldade = dif;
            dto.satisfacao = satis;
            dto.ajuda = ajuda;
            dto.usouAjuda = usouAjuda;

            return View("Index", dto);
        }

        public async Task<ActionResult> AvaliaAjuda(int idConfecao, int dif, int? ajuda, int? satis, bool usouAjuda)
        {

            var dto = new AvaliacaoDto(idConfecao);
            dto.dificuldade = dif;
            dto.satisfacao = satis;
            dto.ajuda = ajuda;
            dto.usouAjuda = usouAjuda;

            return View("Index", dto);
        }

        public async Task<ActionResult> AvaliaSatis(int idConfecao, int dif, int? ajuda, int satis, bool usouAjuda)
        {

            var dto = new AvaliacaoDto(idConfecao);
            dto.dificuldade = dif;
            dto.satisfacao = satis;
            dto.ajuda = ajuda;
            dto.usouAjuda = usouAjuda;

            return View("Index", dto);
        }



        public async Task<ActionResult> Confirma(int idConfecao, int dif, int? ajuda, int satis, bool usouAjuda)
        {
            var client = new HttpClient();
            var response = await client.PostAsync("http://localhost:5000/api/Avaliacao/" + idConfecao + "/" + dif + "/" + ajuda + "/" + satis, null);

            var dto = new AvaliacaoDto(idConfecao);
            dto.dificuldade = dif;
            dto.satisfacao = satis;
            dto.ajuda = ajuda;
            dto.usouAjuda = usouAjuda;

            return View("Resultados",dto);
        }
    }
}