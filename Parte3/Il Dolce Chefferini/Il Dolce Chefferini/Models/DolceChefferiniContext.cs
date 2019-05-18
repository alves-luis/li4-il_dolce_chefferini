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
                entity.HasKey(e => e.id);

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

                entity.HasOne(e => e.ementas)
                    .WithOne();
            });

            modelBuilder.Entity<ConfecaoPasso>(entity =>
            {
                entity.HasKey(e => new {e.confecaoId, e.numeroSequenciaPasso, e.receitaId});

                entity.Property(e => e.confecaoId)
                    .IsRequired()
                    .HasColumnName("confecaoId");

                entity.Property(e => e.tempoEmTicks)
                    .IsRequired()
                    .HasColumnName("tempoEmTicks");

                //entity.HasOne(e => e.passo);

                //entity.HasOne(e => e.confecao);
                
            });

            modelBuilder.Entity<Ementa>(entity =>
            {
                entity.HasKey(e => new {e.almoco, e.utilizadorId, e.diaDaSemana});

                entity.Property(e => e.diaDaSemana)
                    .IsRequired()
                    .HasColumnName("diaDaSemana")
                    .HasMaxLength(64);

                entity.Property(e => e.almoco)
                    .IsRequired()
                    .HasColumnName("almoco");

            });

            modelBuilder.Entity<IngredientePasso>(entity =>
            {
                entity.HasKey(e => new {e.ingredienteId, e.receitaId, e.numeroSequenciaPasso});

                entity.Property(e => e.quantidade)
                    .IsRequired()
                    .HasColumnName("quantidade");

                entity.Property(e => e.unidade)
                    .IsRequired()
                    .HasColumnName("unidade")
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Passo>(entity =>
            {
                entity.HasKey(e => new {e.receitaId, e.numeroSequencia});

                entity.Property(e => e.numeroSequencia)
                    .IsRequired()
                    .HasColumnName("numeroSequencia")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(255);

                entity.Property(e => e.tempoEsperadoEmTicks)
                    .IsRequired()
                    .HasColumnName("tempoEsperadoEmTicks");

                entity.Property(e => e.aspetoEsperado)
                    .IsRequired()
                    .HasColumnName("aspetoEsperado")
                    .HasMaxLength(128);

                entity.Property(e => e.urlVideo)
                    .HasColumnName("urlVideo")
                    .HasMaxLength(512);

               /* entity.HasMany(e => e.ingredientesPassos)
                     .WithOne(); */
            });

            modelBuilder.Entity<Receita>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.Property(e => e.id)
                    .IsRequired()
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(255);

                entity.Property(e => e.descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(511);

                entity.Property(e => e.tempoEsperadoEmTicks)
                    .IsRequired()
                    .HasColumnName("tempoEsperadoEmTicks");

                entity.Property(e => e.grauDificuldade)
                    .IsRequired()
                    .HasColumnName("grauDificuldade");

                entity.Property(e => e.doses)
                    .IsRequired()
                    .HasColumnName("doses");

                entity.Property(e => e.calorias)
                    .IsRequired()
                    .HasColumnName("calorias");

                entity.Property(e => e.lipidos)
                    .IsRequired()
                    .HasColumnName("lipidos");

                entity.Property(e => e.hidratos)
                    .IsRequired()
                    .HasColumnName("hidratos");

                entity.Property(e => e.proteinas)
                    .IsRequired()
                    .HasColumnName("proteinas");

                entity.Property(e => e.criador)
                    .IsRequired()
                    .HasColumnName("criador")
                    .HasMaxLength(64);

               /* entity.HasMany(e => e.passo)
                    .WithOne(); */

            });
            
            modelBuilder.Entity<Confecao>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.id)
                    .IsRequired()
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.usouAjuda)
                    .IsRequired()
                    .HasColumnName("usouAjuda");

                entity.Property(e => e.bemSucedida)
                    .IsRequired()
                    .HasColumnName("bemSucedida");
            });
            
            modelBuilder.Entity<Avaliacao>(entity =>
            {
                entity.HasKey(e => e.confecaoId);
                entity.HasOne(e => e.confecao);

                entity.Property(e => e.dificuldade)
                    .IsRequired()
                    .HasColumnName("dificuldade");

                entity.Property(e => e.utilidadeAjudas)
                    .HasColumnName("utilidadeAjudas");

                entity.Property(e => e.grauSatisfacao)
                    .IsRequired()
                    .HasColumnName("grauSatisfacao");

                entity.Property(e => e.data)
                    .IsRequired()
                    .HasColumnName("data");
            });
            
            modelBuilder.Entity<Temperatura>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.Property(e => e.id)
                    .IsRequired()
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.nome)
                    .IsRequired()
                    .HasColumn("nome")
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Ingrediente>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.Property(e => e.id)
                    .IsRequired()
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(255);

                entity.Property(e => e.imagem)
                    .HasColumnName("image")
                    .HasMaxLength(128);

                entity.Property(e => e.comida)
                    .IsRequired()
                    .HasColumnName("comida");

               /* entity.HasMany(e => e.ingredientesPassos)
                    .WithOne(); */

            });
        }
    }
}