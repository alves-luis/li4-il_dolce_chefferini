using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Il_Dolce_Chefferini.Models
{
    public class Receita
    {
        public Receita()
        {
            id = 1;
            nome = "Receita Default";
            descricao = "Isto é a receita default!";
            grauDificuldade = 1;
            calorias = 10;
            lipidos = 20;
            hidratos = 30;
            proteinas = 40;
            doses = 4;
            criador = "Foo";
            temperatura = new Temperatura();
            temperaturaId = temperatura.id;
            tempoEsperado = TimeSpan.FromMinutes(5);
            passos = new List<Passo>();
            imagem = "pictures/tiramissu.jpg";
        }

        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public long tempoEsperadoEmTicks { get; set; }
        public int grauDificuldade { get; set; }
        public int calorias { get; set; }
        public int lipidos { get; set; }
        public int hidratos { get; set; }
        public int proteinas { get; set; }
        public int doses { get; set; }
        public string criador { get; set; }
        [ForeignKey("Temperatura")]
        public int temperaturaId { get; set; }
        public string imagem { get; set; }

        public virtual Temperatura temperatura { get; set; }

        [NotMapped]
        public TimeSpan tempoEsperado
        {
            get => TimeSpan.FromTicks(tempoEsperadoEmTicks);
            set => tempoEsperadoEmTicks = value.Ticks;
        }

        public virtual ICollection<Passo> passos { get; set; }

        public Passo GetPasso(int ordem)
        {
            if (ordem < passos.Count)
                return passos.ElementAt(ordem);

            return null;
        }

        public int GetNumeroDePassos()
        {
            return passos.Count;
        }
    }
}