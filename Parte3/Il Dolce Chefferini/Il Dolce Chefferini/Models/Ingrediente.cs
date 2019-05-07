using System;
using System.ComponentModel.DataAnnotations;

namespace Il_Dolce_Chefferini.Models
{
    public class Ingrediente
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nome { get; set; }
        public string imagem { get; set; }
        // é comida ou utensílio
        [Required]
        public bool comida { get; set; }

        public Ingrediente()
        {
            id = 1;
            nome = "Ingrediente Default";
            imagem = null;
            comida = true;
        }
    }
}