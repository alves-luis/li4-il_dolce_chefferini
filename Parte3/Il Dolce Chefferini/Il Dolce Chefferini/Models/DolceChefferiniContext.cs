using Microsoft.EntityFrameworkCore;

namespace Il_Dolce_Chefferini.Models
{
    public class DolceChefferiniContext : DbContext
    {
        public DolceChefferiniContext(DbContextOptions<DolceChefferiniContext> options)
            : base(options)
        {
        }

        public DbSet<Utilizador> utilizadores { get; set; }
        public DbSet<Receita> receitas { get; set; }
        public DbSet<Ingrediente> ingredientes { get; set; }
        public DbSet<Confecao> confecoes { get; set; }
        public DbSet<Passo> passos { get; set; }
        public DbSet<Temperatura> temperaturas { get; set; }
        public DbSet<Avaliacao> avaliacoes { get; set; }
        public DbSet<Ementa> ementas { get; set; }
        public DbSet<ConfecaoPasso> confecoesPassos { get; set; }
        public DbSet<IngredientePasso> ingredientesPassos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Utilizador>(entity =>
            {
                entity.Property(e => e.id)
                    .IsRequired()
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(64);

                entity.Property(e => e.password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.HasMany(e => e.confecoes)
                    .WithOne();
            });

            modelBuilder.Entity<ConfecaoPasso>(entity =>
            {
                entity.HasKey(e => new {e.confecaoId, e.numeroSequenciaPasso, e.receitaId});

                entity.Property(e => e.confecaoId)
                    .IsRequired()
                    .HasColumnName("confecaoId");

                entity.HasOne(e => e.passo);

                entity.HasOne(e => e.confecao);
            });

            modelBuilder.Entity<Ementa>(entity =>
            {
                entity.HasKey(e => new {e.almoco, e.utilizadorId, e.diaDaSemana});
            });

            modelBuilder.Entity<IngredientePasso>(entity =>
            {
                entity.HasKey(e => new {e.ingredienteId, e.receitaId, e.numeroSequenciaPasso});
            });

            modelBuilder.Entity<Passo>(entity =>
            {
                entity.HasKey(e => new {e.receitaId, e.numeroSequencia});
            });

            modelBuilder.Entity<Receita>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.id)
                    .IsRequired()
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();
            });
            
            modelBuilder.Entity<Confecao>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.id)
                    .IsRequired()
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();
            });
            
            modelBuilder.Entity<Avaliacao>(entity =>
            {
                entity.HasKey(e => e.confecaoId);
                entity.HasOne(e => e.confecao);
            });
            
            modelBuilder.Entity<Temperatura>(entity =>
            {
                entity.HasKey(e => e.id);
            });
        }
    }
}