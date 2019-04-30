using Microsoft.EntityFrameworkCore;

namespace Il_Dolce_Chefferini.Models
{
    public class UtilizadorContext : DbContext
    {
        private DbSet<Ementa> ementa;
        private DbSet<Utilizador> utilizadores;
        private DbSet<Confecao> confecoes;
    }
}