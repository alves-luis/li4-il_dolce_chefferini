using System;

namespace Il_Dolce_Chefferini.Models
{
    public class Receita
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public TimeSpan tempoEsperado { get; set; }
        public int grauDificuldade { get; set; }
        public int calorias { get; set; }
        public int lipidos { get; set; }
        public int hidratos { get; set; }
        public int proteinas { get; set; }
        public string criador { get; set; }
        public Temperatura temperatura { get; set; }
    }
}