using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Il_Dolce_Chefferini.Models
{
    [Table("ConfecaoPasso")]
    public class ConfecaoPasso
    {
        public ConfecaoPasso()
        {
            confecaoId = 1;
            numeroSequenciaPasso = 1;
            receitaId = 1;
            tempo = TimeSpan.Zero;
        }

        public ConfecaoPasso(Passo p, Confecao c, TimeSpan t)
        {
            tempo = t;
            confecaoId = c.id;
            numeroSequenciaPasso = p.numeroSequencia;
            receitaId = p.receitaId;
        }

        [ForeignKey("Confecao")] public int confecaoId { get; set; }

        [ForeignKey("Passo")] public int numeroSequenciaPasso { get; set; }

        [ForeignKey("Passo")] public int receitaId { get; set; }

        public long tempoEmTicks { get; set; }

        [NotMapped]
        public TimeSpan tempo
        {
            get => TimeSpan.FromTicks(tempoEmTicks);
            set => tempoEmTicks = value.Ticks;
        }

        public virtual Passo passo { get; set; }

        public virtual Confecao confecao { get; set; }
    }
}