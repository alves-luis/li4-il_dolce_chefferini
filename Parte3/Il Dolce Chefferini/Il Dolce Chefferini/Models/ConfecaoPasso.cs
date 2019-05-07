using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Il_Dolce_Chefferini.Models
{
    public class ConfecaoPasso
    {
        public int confecaoId { get; set; }
        public int numeroSequenciaPasso { get; set; }
        public int receitaId { get; set; }
        public Int64 tempoEmTicks { get; set; }

        [NotMapped]
        public TimeSpan tempo
        {
            get => TimeSpan.FromTicks(tempoEmTicks);
            set => tempoEmTicks = value.Ticks;
        }

        [NotMapped]
        [JsonIgnore]
        public Passo passo
        {
            get => passo;
            set
            {
                numeroSequenciaPasso = value.numeroSequencia;
                receitaId = value.receitaId;
            }
        }

        [NotMapped]
        [JsonIgnore]
        public Confecao confecao
        {
            get => confecao; 
            set => confecaoId = value.id;
        }

        public ConfecaoPasso(Passo p, Confecao c, TimeSpan t)
        {
            tempo = t;
            passo = p;
            confecao = c;
        }
    }
}