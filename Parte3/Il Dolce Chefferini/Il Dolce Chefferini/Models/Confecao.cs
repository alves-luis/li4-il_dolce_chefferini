using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Il_Dolce_Chefferini.Models
{
    public class Confecao
    {
        [Key]
        public int id { get; set; }
        public int user { get; set; }
        public Receita receita { get; set; }
        public Avaliacao avaliacao { get; set; }
        public bool usouAjuda { get; set; }
        public bool bemSucedida { get; set; }
        public int passoAtual { get; set; }
        public DateTime inicioPassoAtual { get; set; }
        [NotMapped]
        public Dictionary<Passo,TimeSpan> tempoEmPasso { get; set; }

        public Confecao(int user, Receita r)
        {
            this.user = user;
            receita = r;
            avaliacao = new Avaliacao();
            usouAjuda = false;
            bemSucedida = false;
            passoAtual = 0;
            inicioPassoAtual = DateTime.Now;
            tempoEmPasso = new Dictionary<Passo, TimeSpan>();
        }

        public Confecao(int user, Receita receita, Avaliacao avaliacao, bool usouAjuda, bool bemSucedida, int passoAtual, DateTime inicioPassoAtual, Dictionary<Passo, TimeSpan> tempoEmPasso)
        {
            this.user = user;
            this.receita = receita;
            this.avaliacao = avaliacao;
            this.usouAjuda = usouAjuda;
            this.bemSucedida = bemSucedida;
            this.passoAtual = passoAtual;
            this.inicioPassoAtual = inicioPassoAtual;
            this.tempoEmPasso = tempoEmPasso;
        }

        public Confecao()
        {
            this.id = 0;
            this.user = 0;
            this.receita = new Receita();
            this.avaliacao = new Avaliacao();
            this.usouAjuda = false;
            this.bemSucedida = false;
            this.passoAtual = 0;
            this.inicioPassoAtual = DateTime.Now;
            this.tempoEmPasso = new Dictionary<Passo, TimeSpan>();
        }

        public Passo GetProximoPasso()
        {
            Passo p = receita.GetPasso(passoAtual + 1);
            
            if (p == null) return null;
            
            Passo before = receita.GetPasso(passoAtual);
            tempoEmPasso.Add(before,DateTime.Now - inicioPassoAtual);
            inicioPassoAtual = DateTime.Now;
            passoAtual++;
            return p;
        }

        public void RequereAjuda()
        {
            usouAjuda = true;
        }
    }
}