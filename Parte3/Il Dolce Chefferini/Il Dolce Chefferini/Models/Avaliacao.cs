using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Il_Dolce_Chefferini.Models
{
    [Table("Avaliacao")]
    public class Avaliacao
    {
        public Avaliacao()
        {
            confecaoId = 1;
            dificuldade = 0;
            utilidadeAjudas = null;
            grauSatisfacao = 0;
            data = DateTime.Now;
        }


        public Avaliacao(int idConfecao, int dif, int? ajuda, int grau)
        {
            confecaoId = idConfecao;
            dificuldade = dif;
            grauSatisfacao = grau;
            data = DateTime.Now;
            utilidadeAjudas = ajuda;
        }

        [ForeignKey("Confecao")] public int confecaoId { get; set; }

        [Required] public int dificuldade { get; set; }

        public int? utilidadeAjudas { get; set; }

        [Required] public int grauSatisfacao { get; set; }

        [Required] public DateTime data { get; set; }

        public virtual Confecao confecao { get; set; }
    }
}