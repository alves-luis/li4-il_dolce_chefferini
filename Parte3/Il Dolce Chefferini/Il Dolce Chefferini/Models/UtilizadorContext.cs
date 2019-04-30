using Microsoft.EntityFrameworkCore;

namespace Il_Dolce_Chefferini.Models
{
    public class UtilizadorContext : DbContext
    {
        public DbSet<Ementa> ementa { get; set; }
        public DbSet<Utilizador> utilizadores { get; set; }
        public DbSet<Confecao> confecoes { get; set; }

        public UtilizadorContext(DbContextOptions<UtilizadorContext> options) : base(options)
        {    
        }
        
    }
}