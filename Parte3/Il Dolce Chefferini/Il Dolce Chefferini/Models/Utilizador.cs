using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Il_Dolce_Chefferini.Models
{
    public class Utilizador
    {
        public Utilizador()
        {
            id = 1;
            email = "foo@bar.foo";
            password = "password";
            confecoes = new List<Confecao>();
        }

        [Key] public int id { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        // for mapping to db
        public ICollection<Confecao> confecoes { get; set; }

        // retorna o número de tentativas falhadas de uma receita
        public int GetTentativasFalhadasDeReceita(int idReceita)
        {
            return confecoes.Count(confecao => confecao.id == idReceita && !confecao.bemSucedida);
        }

        // retorna o número de confeções de uma receita
        public int GetNumConfecoesDeReceita(int idReceita)
        {
            return confecoes.Count(confecao => confecao.id == idReceita);
        }

        // adiciona uma confeção ao utilizador
        public void AdicionaConfecaoDeReceita(Confecao c)
        {
            confecoes.Add(c);
        }

        // Dado o ID de uma receita, retorna o tempo médio de preparação da receita.
        // Caso nunca tenha confecionado essa receita, retorna TimeSpan de 0.
        public TimeSpan GetTempoMedioPreparacaoReceita(int receitaId)
        {
            var averageTicks = confecoes.Where(c => c.id == receitaId)
                .Average(confecao => confecao.GetTempoTotalDeConfecao().Ticks);

            return new TimeSpan(Convert.ToInt64(averageTicks));
        }
    }
}