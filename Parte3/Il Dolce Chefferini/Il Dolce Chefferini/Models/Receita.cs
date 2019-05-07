using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Il_Dolce_Chefferini.Models
{
    public class Receita
    {
        
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public Int64 tempoEsperadoEmTicks { get; set; }
        public int grauDificuldade { get; set; }
        public int calorias { get; set; }
        public int lipidos { get; set; }
        public int hidratos { get; set; }
        public int proteinas { get; set; }
        public int doses { get; set; }
        public string criador { get; set; }
        public int temperaturaId { get; set; }

        [NotMapped]
        public Temperatura temperatura { get; set; }

        [NotMapped]
        public TimeSpan tempoEsperado
        {
            get => TimeSpan.FromTicks(tempoEsperadoEmTicks);
            set => tempoEsperadoEmTicks = value.Ticks;
        }

        public ICollection<Passo> passos { get; set; }

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
        }

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