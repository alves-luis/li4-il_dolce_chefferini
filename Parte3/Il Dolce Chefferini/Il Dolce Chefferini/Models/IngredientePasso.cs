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
        public Ingrediente ingrediente
        {
            get => ingrediente; 
            set => ingredienteId = value.id;
        }

        [NotMapped]
        public Passo passo
        {
            get => passo;
            set
            {
                receitaId = value.receitaId;
                numeroSequenciaPasso = value.numeroSequencia;
            }
        }
    }
}