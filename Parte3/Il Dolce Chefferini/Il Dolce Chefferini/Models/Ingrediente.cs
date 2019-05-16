using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Il_Dolce_Chefferini.Models
{
    public class Ingrediente
    {
        public Ingrediente()
        {
            id = 1;
            nome = "Ingrediente Default";
            imagem = null;
            comida = true;
        }

        [Key] public int id { get; set; }

        [Required] public string nome { get; set; }

        public string imagem { get; set; }

        // é comida ou utensílio
        [Required] public bool comida { get; set; }
    }
}