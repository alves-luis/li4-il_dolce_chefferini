using System.ComponentModel.DataAnnotations.Schema;

namespace Il_Dolce_Chefferini.Models
{
    public class Ementa
    {
        public Ementa()
        {
            utilizadorId = 1;
            receitaId = 1;
            diaDaSemana = "domingo";
            almoco = true;
            utilizador = new Utilizador();
            receita = new Receita();
        }

        [ForeignKey("Utilizador")] public int utilizadorId { get; set; }

        [ForeignKey("Receita")] public int receitaId { get; set; }

        public string diaDaSemana { get; set; }
        public bool almoco { get; set; }

        public virtual Utilizador utilizador { get; set; }

        public virtual Receita receita { get; set; }
    }
}