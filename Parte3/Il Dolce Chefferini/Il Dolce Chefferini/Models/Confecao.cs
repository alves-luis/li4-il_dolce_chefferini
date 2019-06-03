using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Il_Dolce_Chefferini.Models
{
    [Table("Confecao")]
    public class Confecao
    {

        public Confecao()
        {
            id = 1;
            usouAjuda = false;
            bemSucedida = false;
            avaliacao = null;
            passoAtual = 0;
            inicioPassoAtual = DateTime.Now;
        }

        public Confecao(int receitaId)
        {
            this.receitaId = receitaId;
            utilizadorId = 1;
            usouAjuda = false;
            bemSucedida = false;
            avaliacao = null;
            passoAtual = 0;
            inicioPassoAtual = DateTime.Now;
        }

        [Key] public int id { get; set; }

        public bool usouAjuda { get; set; }
        public bool bemSucedida { get; set; }

        [ForeignKey("Utilizador")] public int utilizadorId { get; set; }

        [ForeignKey("Receita")] public int receitaId { get; set; }

        public Avaliacao avaliacao { get; set; }

        public int passoAtual { get; set; }

        public DateTime inicioPassoAtual { get; set; }

        public virtual Utilizador utilizador { get; set; }

        public virtual Receita receita { get; set; }

        public virtual ICollection<ConfecaoPasso> tempoEmPasso { get; set; }

        // retorna o passo seguinte da confecao
        public Passo GetProximoPasso()
        {
            var p = receita.GetPasso(passoAtual + 1);

            if (p == null) return null;

            if (passoAtual >= 0)
            {
                var before = receita.GetPasso(passoAtual);
                tempoEmPasso.Add(new ConfecaoPasso(before, this, DateTime.Now - inicioPassoAtual));
            }

            inicioPassoAtual = DateTime.Now;
            passoAtual++;
            return p;
        }

        public void RequereAjuda()
        {
            usouAjuda = true;
        }

        public void AvaliaConfecao(int dif, int? ajuda, int satis)
        {
            avaliacao = new Avaliacao(this.id,dif,ajuda,satis);
        }

        public void TerminaConfecao()
        {
            var numeroDePassos = receita.GetNumeroDePassos();
            if (numeroDePassos != passoAtual)
                bemSucedida = false;
            else
                bemSucedida = true;
        }

        public TimeSpan GetTempoTotalDeConfecao()
        {
            var sum = TimeSpan.Zero;
            foreach (var p in tempoEmPasso) sum.Add(p.tempo);

            return sum;
        }

        public void IniciaPasso()
        {
            inicioPassoAtual = DateTime.Now;
        }

        public void FinalizaPasso()
        {
            if (passoAtual < receita.GetNumeroDePassos())
            {
                var passoAntes = receita.GetPasso(passoAtual);
                tempoEmPasso.Add(new ConfecaoPasso(passoAntes, this, DateTime.Now - inicioPassoAtual));
                passoAtual++;
            }
        }
    }
}