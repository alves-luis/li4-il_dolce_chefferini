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
        public Utilizador utilizador { get; set; }
        [NotMapped]
        public Receita receita { get; set; }

        public Ementa()
        {
            utilizadorId = 1;
            receitaId = 1;
            diaDaSemana = "domingo";
            almoco = true;
            utilizador = new Utilizador();
            receita = new Receita();
        }

    }
}