using System.Collections.Generic;
using Il_Dolce_Chefferini.Models;

namespace Il_Dolce_Chefferini.Dto
{
    public class EmentaDto
    {
        public Utilizador utilizador { get; set; }
        public string diaDaSemana { get; set; }
        public bool? almoco { get; set; }
        public int? receitaId { get; set; }
        public ICollection<Receita> receitas { get; set; }
        public IEnumerable<Ementa> ementas { get; set; }
        public bool sucesso { get; set; }

        public EmentaDto(Utilizador u)
        {
            diaDaSemana = null;
            almoco = null;
            receitaId = null;
            receitas = null;
            utilizador = u;
            sucesso = false;
            ementas = new List<Ementa>();
        }

        public bool AllSelected()
        {
            if (utilizador != null && null != diaDaSemana && null != receitaId && receitas != null)
                return true;
            return false;
        }
    }
}