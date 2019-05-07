using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Il_Dolce_Chefferini.Models
{
    public class IngredientePasso
    {
        public int receitaId { get; set; }
        public int numeroSequenciaPasso { get; set; }
        public int ingredienteId { get; set; }
        public int quantidade { get; set; }
        public string unidade { get; set; }

        [NotMapped]
        public Ingrediente ingrediente { get; set; }

        [NotMapped]
        public Passo passo { get; set; }

        public IngredientePasso()
        {
            receitaId = 1;
            numeroSequenciaPasso = 1;
            ingredienteId = 1;
            quantidade = 1;
            unidade = "kg";
            ingrediente = new Ingrediente();
        }
        
        public IngredientePasso(Ingrediente i, Passo p, int qt, string un)
        {
            receitaId = p.receitaId;
            numeroSequenciaPasso = p.numeroSequencia;
            ingredienteId = i.id;
            quantidade = qt;
            unidade = un;
            ingrediente = i;
            passo = p;
        }
    }
}