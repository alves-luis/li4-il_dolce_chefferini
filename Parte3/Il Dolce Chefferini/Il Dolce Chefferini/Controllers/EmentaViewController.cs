using System.Collections;
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
    public class EmentaViewController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:5000/api/Utilizadores/1");
            var utilizador = await response.Content.ReadAsAsync<Utilizador>();
            response = await client.GetAsync("http://localhost:5000/api/Receitas");
            var receitas = response.Content.ReadAsAsync<ICollection<Receita>>().Result;
            
            var dto = new EmentaDto(utilizador);
            dto.receitas = receitas;
            dto.sucesso = false;
            
            response = await client.GetAsync("http://localhost:5000/api/Ementa/1");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var ementas = await response.Content.ReadAsAsync<IEnumerable<Ementa>>();
                dto.ementas = ementas.OrderByDescending(e => e.diaDaSemana);
            }
   
            return View(dto);
        }

        public async Task<ActionResult> DiaDaSemana(string dia, bool? refeicao, int? receitaId)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:5000/api/Utilizadores/1");
            var utilizador = await response.Content.ReadAsAsync<Utilizador>();
            response = await client.GetAsync("http://localhost:5000/api/Receitas");
            var receitas = response.Content.ReadAsAsync<ICollection<Receita>>().Result;
            
            
            var dto = new EmentaDto(utilizador);
            dto.almoco = refeicao;
            dto.diaDaSemana = dia;
            dto.receitas = receitas;
            dto.receitaId = receitaId;
            dto.sucesso = false;
            response = await client.GetAsync("http://localhost:5000/api/Ementa/1");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var ementas = await response.Content.ReadAsAsync<IEnumerable<Ementa>>();
                dto.ementas = ementas.OrderByDescending(e => e.diaDaSemana);
            }
            return View("Index",dto);
        }
        
        public async Task<ActionResult> Refeicao(string dia, bool refeicao, int? receitaId)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:5000/api/Utilizadores/1");
            var utilizador = await response.Content.ReadAsAsync<Utilizador>();
            response = await client.GetAsync("http://localhost:5000/api/Receitas");
            var receitas = response.Content.ReadAsAsync<ICollection<Receita>>().Result;

            var dto = new EmentaDto(utilizador);
            dto.almoco = refeicao;
            dto.diaDaSemana = dia;
            dto.receitas = receitas;
            dto.receitaId = receitaId;
            dto.sucesso = false;
            response = await client.GetAsync("http://localhost:5000/api/Ementa/1");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var ementas = await response.Content.ReadAsAsync<IEnumerable<Ementa>>();
                dto.ementas = ementas.OrderByDescending(e => e.diaDaSemana);
            }
            return View("Index",dto);
        }

        public async Task<ActionResult> Receita(string dia, bool? refeicao, int receitaId)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:5000/api/Utilizadores/1");
            var utilizador = await response.Content.ReadAsAsync<Utilizador>();
            response = await client.GetAsync("http://localhost:5000/api/Receitas");
            var receitas = response.Content.ReadAsAsync<ICollection<Receita>>().Result;
            
            
            var dto = new EmentaDto(utilizador);
            dto.almoco = refeicao;
            dto.diaDaSemana = dia;
            dto.receitas = receitas;
            dto.receitaId = receitaId;
            dto.sucesso = false;
            response = await client.GetAsync("http://localhost:5000/api/Ementa/1");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var ementas = await response.Content.ReadAsAsync<IEnumerable<Ementa>>();
                dto.ementas = ementas.OrderByDescending(e => e.diaDaSemana);
            }
            return View("Index",dto);
        }

        public async Task<ActionResult> Confirma(string dia, bool? refeicao, int? receitaId)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:5000/api/Utilizadores/1");
            var utilizador = await response.Content.ReadAsAsync<Utilizador>();
            response = await client.GetAsync("http://localhost:5000/api/Receitas");
            var receitas = response.Content.ReadAsAsync<ICollection<Receita>>().Result;
            
            response = await client.PostAsync("http://localhost:5000/api/Ementa/1/" + dia + "/" + refeicao + "/" + receitaId,null);
            
            var dto = new EmentaDto(utilizador);
            
            if (response.StatusCode == HttpStatusCode.Created)
                dto.sucesso = true;
            else
                dto.sucesso = false;
            
            
            dto.almoco = refeicao;
            dto.diaDaSemana = dia;
            dto.receitas = receitas;
            dto.receitaId = receitaId;
            response = await client.GetAsync("http://localhost:5000/api/Ementa/1");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var ementas = await response.Content.ReadAsAsync<IEnumerable<Ementa>>();
                dto.ementas = ementas.OrderByDescending(e => e.diaDaSemana);
            }

            return View("Index",dto);
        }
    }
}