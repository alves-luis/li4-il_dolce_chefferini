using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;

namespace Il_Dolce_Chefferini.Models
{
    public class IlDolceChefferiniContext : DbContext
    {
        public DbSet<Utilizador> utilizadores { get; set; }
        public DbSet<Receita> receitas { get; set; }
        public DbSet<Ingrediente> ingredientes { get; set; }
        public DbSet<Confecao> confecoes { get; set; }
        public DbSet<Passo> passos { get; set; }
        public DbSet<Temperatura> temperaturas { get; set; }
        public DbSet<Avaliacao> avaliacoes { get; set; }
        public DbSet<Ementa> ementas { get; set; }

        public IlDolceChefferiniContext(DbContextOptions<IlDolceChefferiniContext> options) 
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Utilizador>(entity =>
            {
                entity.Property(e => e.id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.email)
                    .IsRequired()
                    .HasColumnName("E-mail")
                    .HasMaxLength(64);

                entity.Property(e => e.password)
                    .IsRequired()
                    .HasColumnName("Password");
            });

        }
    }
}