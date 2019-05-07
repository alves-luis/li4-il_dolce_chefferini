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
        public Temperatura temperatura
        {
            get => temperatura; 
            set => temperaturaId = value.id;
        }

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
            calorias = 20;
            criador = "Admin";
            descricao = "Receita gerada automaticamente";
            grauDificuldade = 5;
            hidratos = 20;
            lipidos = 20;
            nome = "Receita Automática";
            proteinas = 20;
            temperatura = new Temperatura();
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