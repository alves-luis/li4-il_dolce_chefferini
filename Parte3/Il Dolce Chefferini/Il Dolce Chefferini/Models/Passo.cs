using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Il_Dolce_Chefferini.Models
{
    [Table("Passo")]
    public class Passo
    {
        public Passo()
        {
            receitaId = 1;
            numeroSequencia = 1;
            ingredientes = new List<IngredientePasso>();
        }

        public Passo(Receita r, TimeSpan tempo, int nr, string desc, string localFicheiro, string video)
        {
            receitaId = r.id;
            numeroSequencia = nr;
            descricao = desc;
            tempoEsperado = tempo;
            aspetoEsperado = localFicheiro;
            receita = r;
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