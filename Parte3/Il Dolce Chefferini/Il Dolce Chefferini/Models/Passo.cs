using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Il_Dolce_Chefferini.Models
{
    public class Passo
    {
        public int receitaId { get; set; }
        public int numeroSequencia { get; set; }
        public string descricao { get; set; }
        public Int64 tempoEsperadoEmTicks { get; set; }
        // localização do ficheiro com a imagem do aspeto esperado
        public string aspetoEsperado { get; set; }

        [NotMapped]
        public Receita receita
        {
            get => receita;
            set => receitaId = value.id;
        }
        [NotMapped]
        public TimeSpan tempoEsperado { 
            get => TimeSpan.FromTicks(tempoEsperadoEmTicks);
            set => tempoEsperadoEmTicks = value.Ticks;
        }
        
        public ICollection<IngredientePasso> ingredientes { get; set; }
    }
}