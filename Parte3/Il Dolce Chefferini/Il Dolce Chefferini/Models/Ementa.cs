using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Il_Dolce_Chefferini.Models
{
    public class Ementa
    {
        [ForeignKey("Utilizador")]
        public int utilizadorId { get; set; }
        [ForeignKey("Receita")]
        public int receitaId { get; set; }
        public string diaDaSemana { get; set; }
        public bool almoco { get; set; }

        [NotMapped] 
        public Utilizador utilizador;
        [NotMapped]
        public Receita receita;

    }
}