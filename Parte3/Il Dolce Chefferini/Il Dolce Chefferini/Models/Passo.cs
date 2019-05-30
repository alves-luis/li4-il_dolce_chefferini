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
            aspetoEsperado = "pictures/passo1.jpg";
            urlVideo = "https://www.youtube.com/watch?v=tx72s86URhA";

        }

        public Passo(Receita r, TimeSpan tempo, int nr, string desc, string localFicheiro, string video)
        {
            receitaId = r.id;
            numeroSequencia = nr;
            descricao = desc;
            tempoEsperado = tempo;
            aspetoEsperado = localFicheiro;
            urlVideo = video;
        }

        [ForeignKey("Receita")]
        public int receitaId { get; set; }
        public int numeroSequencia { get; set; }
        public string descricao { get; set; }
        public string urlVideo { get; set; }

        public long tempoEsperadoEmTicks { get; set; }

        // localização do ficheiro com a imagem do aspeto esperado
        public string aspetoEsperado { get; set; }

        public virtual Receita receita { get; set; }

        [NotMapped]
        public TimeSpan tempoEsperado
        {
            get => TimeSpan.FromTicks(tempoEsperadoEmTicks);
            set => tempoEsperadoEmTicks = value.Ticks;
        }

        public virtual ICollection<IngredientePasso> ingredientes { get; set; }
    }
}