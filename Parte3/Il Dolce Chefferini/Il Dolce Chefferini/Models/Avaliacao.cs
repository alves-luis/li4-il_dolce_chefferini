using System;

namespace Il_Dolce_Chefferini.Models
{
    public class Avaliacao
    {
        public int id { get; set; }
        public int dificuldade { get; set; }
        public int utilidadeAjudas { get; set; }
        public int grauSatisfacao { get; set; }
        public DateTime data { get; set; }

        public Avaliacao(int ID, int dif, int util, int grau)
        {
            id = ID;
            dificuldade = dif;
            utilidadeAjudas = util;
            grauSatisfacao = grau;
            data = DateTime.Now;
        }

        public Avaliacao()
        {
            id = 1;
            dificuldade = 1;
            utilidadeAjudas = 1;
            grauSatisfacao = 1;
            data = DateTime.Now;
        }
    }
}