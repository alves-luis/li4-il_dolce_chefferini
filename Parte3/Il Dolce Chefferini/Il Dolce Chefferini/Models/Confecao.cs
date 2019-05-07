using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Metadata.Edm;

namespace Il_Dolce_Chefferini.Models
{
    public class Confecao
    {
        private static int _nextId;
        [Key]
        public int id { get; set; }
        public bool usouAjuda { get; set; }
        public bool bemSucedida { get; set; }
        [ForeignKey("Utilizador")]
        public int utilizadorId { get; set; }
        [ForeignKey("Receita")]
        public int receitaId { get; set; }
        public Avaliacao avaliacao { get; set; }
        
        [NotMapped]
        public int passoAtual { get; set; }
        [NotMapped]
        public DateTime inicioPassoAtual { get; set; }
        [NotMapped]
        public Utilizador utilizador { get; set; }

        [NotMapped]
        public Receita receita { get; set; }
        
        public ICollection<ConfecaoPasso> tempoEmPasso { get; set; }

        public Confecao()
        {
            id = _nextId++;
            usouAjuda = false;
            bemSucedida = false;
            utilizador = new Utilizador();
            avaliacao = null;
            passoAtual = 1;
            inicioPassoAtual = DateTime.Now;
            receita = new Receita();
            tempoEmPasso = new List<ConfecaoPasso>();
            utilizadorId = utilizador.id;
            receitaId = receita.id;
        }

        // retorna o passo seguinte da confecao
        public Passo GetProximoPasso()
        {
            Passo p = receita.GetPasso(passoAtual + 1);
            
            if (p == null) return null;
            
            Passo before = receita.GetPasso(passoAtual);
            tempoEmPasso.Add(new ConfecaoPasso(before,this,DateTime.Now - inicioPassoAtual));
            inicioPassoAtual = DateTime.Now;
            passoAtual++;
            return p;
        }

        public void RequereAjuda()
        {
            usouAjuda = true;
        }

        public void AvaliaConfecao(int dificuldade, int grauSatisfacao)
        {
            avaliacao = new Avaliacao(this,dificuldade,grauSatisfacao);
        }

        public void TerminaConfecao()
        {
            int numeroDePassos = receita.GetNumeroDePassos();
            if (numeroDePassos > passoAtual)
                bemSucedida = false;
            else
                bemSucedida = true;
        }

        public TimeSpan GetTempoTotalDeConfecao()
        {
            TimeSpan sum = TimeSpan.Zero;
            foreach (ConfecaoPasso p in tempoEmPasso)
            {
                sum.Add(p.tempo);
            }

            return sum;
        }
    }
}