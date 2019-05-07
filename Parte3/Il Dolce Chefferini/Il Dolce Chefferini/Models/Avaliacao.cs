using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Il_Dolce_Chefferini.Models
{
    public class Avaliacao
    {
        [ForeignKey("Confecao")]
        [Key]
        public int confecaoId { get; set; }
        [Required]
        public int dificuldade { get; set; }
        public int? utilidadeAjudas { get; set; }
        [Required]
        public int grauSatisfacao { get; set; }
        [Required]
        public DateTime data { get; set; }

        [NotMapped]
        public Confecao confecao
        {
            get => confecao; 
            set => confecaoId = value.id;
        }
        
        public Avaliacao(Confecao c, int dif, int grau)
        {
            confecao = c;
            dificuldade = dif;
            grauSatisfacao = grau;
            data = DateTime.Now;
            utilidadeAjudas = null;
        }
    }
}