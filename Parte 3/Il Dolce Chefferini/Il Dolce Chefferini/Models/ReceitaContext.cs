using Microsoft.EntityFrameworkCore;

namespace Il_Dolce_Chefferini.Models
{
    public class ReceitaContext : DbContext
    {
        public ReceitaContext(DbContextOptions<ReceitaContext> options) : base(options)
        {
        }
        
        public DbSet<Receita> Receitas { get; set; }
    }
}