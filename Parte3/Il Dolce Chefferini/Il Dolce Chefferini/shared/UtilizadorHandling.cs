using System.Linq;
using Il_Dolce_Chefferini.Helpers;
using Il_Dolce_Chefferini.Models;
using Microsoft.EntityFrameworkCore;

namespace Il_Dolce_Chefferini.shared
{
    public class UtilizadorHandling
    {
        private readonly DolceChefferiniContext _context;

        public UtilizadorHandling(DolceChefferiniContext context)
        {
            _context = context;
        }

        public bool ValidarUtilizador(Utilizador u)
        {
            u.password = MyHelpers.HashPassword(u.password);
            var utilizador = _context.utilizadores
                .FirstOrDefault(b => b.email == u.email && b.password == u.password);

            return utilizador == null;
        }

        public bool RegistarUtilizador(Utilizador u)
        {
            u.password = MyHelpers.HashPassword(u.password);
            _context.utilizadores.Add(u);
            _context.SaveChanges();
            return true;
        }

        public bool IniciarConfecao(Confecao c)
        {
            _context.confecoes.Add(c);
            _context.SaveChanges();
            return true;
        }

        public bool FinalizarConfecao(Confecao c)
        {
            var u = _context.utilizadores.Find(c.utilizador);
            if (u == null)
                return false;
            u.AdicionaConfecaoDeReceita(c);
            _context.Entry(c).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
    }
}