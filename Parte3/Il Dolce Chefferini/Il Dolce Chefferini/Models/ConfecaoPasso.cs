using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Il_Dolce_Chefferini.Models
{
    public class ConfecaoPasso
    {
        [ForeignKey("Confecao")]
        public int confecaoId { get; set; }
        [ForeignKey("Passo")]
        public int numeroSequenciaPasso { get; set; }
        [ForeignKey("Passo")]
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
        public Passo passo { get; set; }

        [NotMapped]
        [JsonIgnore]
        public Confecao confecao { get; set; }

        public ConfecaoPasso()
        {
            confecaoId = 1;
            numeroSequenciaPasso = 1;
            receitaId = 1;
            tempo = TimeSpan.Zero;
            passo = new Passo();
            confecao = new Confecao();
        }
        
        public ConfecaoPasso(Passo p, Confecao c, TimeSpan t)
        {
            tempo = t;
            passo = p;
            confecao = c;
            confecaoId = c.id;
            numeroSequenciaPasso = p.numeroSequencia;
            receitaId = p.receitaId;
        }
    }
}