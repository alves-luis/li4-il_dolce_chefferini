using System.ComponentModel.DataAnnotations.Schema;

namespace Il_Dolce_Chefferini.Models
{
    public class IngredientePasso
    {
        public IngredientePasso()
        {
            receitaId = 1;
            numeroSequenciaPasso = 1;
            ingredienteId = 1;
            quantidade = 1;
            unidade = "kg";
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

        [ForeignKey("Receita")]
        public int receitaId { get; set; }
        [ForeignKey("Passo")]
        public int numeroSequenciaPasso { get; set; }
        [ForeignKey("Ingrediente")]
        public int ingredienteId { get; set; }
        public int quantidade { get; set; }
        public string unidade { get; set; }

        public virtual Ingrediente ingrediente { get; set; }

        public virtual Passo passo { get; set; }
    }
}