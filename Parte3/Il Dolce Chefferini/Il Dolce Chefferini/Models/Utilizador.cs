using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Il_Dolce_Chefferini.Models
{
    public class Utilizador
    {
        [Key]
        public int Id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        // id da confecao -> nº de tentativas falhadas
        [NotMapped]
        private Dictionary<int, int> tentativasFalhadas;
        // id da confecao -> lista das confecoes
        [NotMapped]
        private Dictionary<int, List<Confecao>> confecoesPorIdReceita;

        public int GetTentativasFalhadasDeReceita(int idReceita)
        {
            var success = tentativasFalhadas.TryGetValue(idReceita, out var numTentativas);
            return success ? numTentativas : 0;
        }

        public int GetNumConfecoesDeReceita(int idReceita)
        {
            var success = confecoesPorIdReceita.TryGetValue(idReceita, out var confecoes);
            
            return success ? confecoes.Count : 0;
        }

        public void AdicionaConfecaoDeReceita(Confecao c)
        {
            if (!c.bemSucedida)
            {
                if (tentativasFalhadas.ContainsKey(c.receita.Id))
                {
                    tentativasFalhadas.TryGetValue(c.receita.Id, out var oldValue);
                    tentativasFalhadas.Add(c.receita.Id,oldValue + 1);
                }
                else
                {
                    tentativasFalhadas.Add(c.receita.Id,1);
                }
            }

            var success = confecoesPorIdReceita.TryGetValue(c.receita.Id, out var confecoes);
            if (success)
            {
                confecoes.Add(c);
            }
            else
            {
                List<Confecao> lista = new List<Confecao> {c};
                confecoesPorIdReceita.Add(c.receita.Id,lista);
            }
        }
    }
}