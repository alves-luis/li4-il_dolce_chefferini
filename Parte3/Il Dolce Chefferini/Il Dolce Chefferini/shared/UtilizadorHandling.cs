using System;
using System.Linq;
using System.Runtime.InteropServices;
using Il_Dolce_Chefferini.Models;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;

namespace Il_Dolce_Chefferini.shared
{
    public class UtilizadorHandling
    {
        private readonly UtilizadorContext _context;

        public UtilizadorHandling(UtilizadorContext context)
        {
            _context = context;
        }

        public bool ValidarUtilizador(Utilizador u)
        {
            u.password = Helpers.MyHelpers.HashPassword(u.password);
            Utilizador utilizador = _context.utilizadores
                .FirstOrDefault(b => b.email == u.email && b.password == u.password);

            return utilizador == null;
        }

        public bool RegistarUtilizador(Utilizador u)
        {
            u.password = Helpers.MyHelpers.HashPassword(u.password);
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
            var u =  _context.utilizadores.Find(c.user);
            if (u == null)
                return false;
            u.AdicionaConfecaoDeReceita(c);
            _context.Entry(c).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
    }
}