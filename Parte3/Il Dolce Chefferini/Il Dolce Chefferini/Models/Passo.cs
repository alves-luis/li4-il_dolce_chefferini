using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Il_Dolce_Chefferini.Models
{
    public class Passo
    {
        public Passo()
        {
            receitaId = 1;
            numeroSequencia = 1;
        }

        public Passo(Receita r, TimeSpan tempo, int nr, string desc, string localFicheiro)
        {
            receitaId = r.id;
            numeroSequencia = nr;
            descricao = desc;
            tempoEsperado = tempo;
            aspetoEsperado = localFicheiro;
            receita = r;
        }

        public int receitaId { get; set; }
        public int numeroSequencia { get; set; }
        public string descricao { get; set; }

        public long tempoEsperadoEmTicks { get; set; }

        // localização do ficheiro com a imagem do aspeto esperado
        public string aspetoEsperado { get; set; }

        [NotMapped] public Receita receita { get; set; }

        [NotMapped]
        public TimeSpan tempoEsperado
        {
            get => TimeSpan.FromTicks(tempoEsperadoEmTicks);
            set => tempoEsperadoEmTicks = value.Ticks;
        }

        public ICollection<IngredientePasso> ingredientes { get; set; }
    }
}