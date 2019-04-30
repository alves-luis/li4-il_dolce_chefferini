using System.Collections.Generic;

namespace Il_Dolce_Chefferini.Models
{
    public class Utilizador
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        private Dictionary<int, int> tentativasFalhadas;
        private Dictionary<int, List<Confecao>> confecoesPorIdReceita;

        public int GetTentativasDeReceita(int idReceita)
        {
            tentativasFalhadas.TryGetValue(idReceita, out var numTentativas);
            return numTentativas;
        }

        public int GetNumConfecoesDeReceita(int idReceita)
        {
            var success = confecoesPorIdReceita.TryGetValue(idReceita, out var confecoes);
            
            return success ? confecoes.Count : 0;
        }

        public bool AdicionaConfecaoDeReceita(Confecao c)
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
             
        }
    }
}