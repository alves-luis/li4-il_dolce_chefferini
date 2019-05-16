using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Il_Dolce_Chefferini.Models
{
    public class Avaliacao
    {
        public Avaliacao()
        {
            confecaoId = 1;
            dificuldade = 0;
            utilidadeAjudas = null;
            grauSatisfacao = 0;
            data = DateTime.Now;
            confecao = new Confecao();
        }

        public Avaliacao(Confecao c, int dif, int grau)
        {
            confecaoId = c.id;
            confecao = c;
            dificuldade = dif;
            grauSatisfacao = grau;
            data = DateTime.Now;
            utilidadeAjudas = null;
        }

        [ForeignKey("Confecao")] public int confecaoId { get; set; }

        [Required] public int dificuldade { get; set; }

        public int? utilidadeAjudas { get; set; }

        [Required] public int grauSatisfacao { get; set; }

        [Required] public DateTime data { get; set; }

        [NotMapped] public Confecao confecao { get; set; }
    }
}