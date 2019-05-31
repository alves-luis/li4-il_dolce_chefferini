using System;
using Il_Dolce_Chefferini.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Il_Dolce_Chefferini.shared
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider service)
        {
            using (var context = new DolceChefferiniContext(
                service.GetRequiredService<DbContextOptions<DolceChefferiniContext>>()))
            {
                Ingrediente champanhe = new Ingrediente(1, "palitos de champanhe", true);
                Ingrediente mascarpone = new Ingrediente(2, "queijo mascarpone", true);
                Ingrediente ovo = new Ingrediente(3, "ovos", true);
                Ingrediente cafe = new Ingrediente(4, "café", true);
                Ingrediente acucar = new Ingrediente(5, "açúcar", true);
                Ingrediente brandy = new Ingrediente(6, "brandy", true);
                Ingrediente cacau = new Ingrediente(7, "cacau", true);
                Ingrediente taca = new Ingrediente(8, "taça", false);
                context.ingredientes.Add(champanhe);
                context.ingredientes.Add(mascarpone);
                context.ingredientes.Add(ovo);
                context.ingredientes.Add(cafe);
                context.ingredientes.Add(acucar);
                context.ingredientes.Add(brandy);
                context.ingredientes.Add(cacau);
                context.ingredientes.Add(taca);

                Temperatura t = new Temperatura();
                t.id = 1;
                t.nome = "Fria";
                context.temperaturas.Add(t);

                Receita r = new Receita();
                r.nome = "Tiramisú";
                r.descricao =
                    "O tiramisú é uma sobremesa italiana, possivelmente originária da cidade de Treviso, na região do Vêneto e que consiste em camadas de biscoitos de champagne entremeadas por um creme doce";
                r.doses = 10;
                r.tempoEsperado = TimeSpan.FromSeconds(55);
                r.grauDificuldade = 2;
                r.calorias = 492;
                r.lipidos = 32;
                r.hidratos = 42;
                r.proteinas = 8;
                r.criador = "admin";
                r.imagem = "pictures/tiramissu.jpg";
                r.temperatura = t;
                r.temperaturaId = t.id;

                Passo p1 = new Passo();
                p1.receitaId = 1;
                p1.descricao = "Parta os ovos e separe as gemas das claras";
                p1.tempoEsperado = TimeSpan.FromSeconds(55);
                p1.numeroSequencia = 1;
                p1.receita = r;
                p1.aspetoEsperado = "pictures/passo1.jpg";
                p1.urlVideo = "https://www.youtube.com/watch?v=tx72s86URhA";


                IngredientePasso i1 = new IngredientePasso(ovo, p1, 6, "unitário");
               // p1.ingredientes.Add(i1);
                
                context.passos.Add(p1);
                context.ingredientesPassos.Add(i1);
                
                Passo p2 = new Passo();
                p2.receitaId = 1;
                p2.descricao = "Junte os 180g de açúcar às gemas e bata até ficar uma gemada esbranquiçada";
                p2.tempoEsperado = TimeSpan.FromSeconds(180);
                p2.numeroSequencia = 2;
                p2.receita = r;

                IngredientePasso i2 = new IngredientePasso(acucar, p2, 180, "gramas");
               // p2.ingredientes.Add(i2);
                
                context.passos.Add(p2);
                context.ingredientesPassos.Add(i2);
                
                Passo p3 = new Passo();
                p3.receitaId = 1;
                p3.descricao = "Junte o queijo e bata tudo até ficar um creme liso";
                p3.tempoEsperado = TimeSpan.FromSeconds(180);
                p3.numeroSequencia = 3;
                p3.receita = r;
                
                IngredientePasso i3 = new IngredientePasso(mascarpone, p3, 600, "gramas");
              //  p3.ingredientes.Add(i3);

                context.passos.Add(p3);
                context.ingredientesPassos.Add(i3);
                
                Passo p4 = new Passo();
                p4.receitaId = 1;
                p4.descricao = "Bata as claras em castelo";
                p4.tempoEsperado = TimeSpan.FromSeconds(180);
                p4.numeroSequencia = 4;
                p4.receita = r;
                
                context.passos.Add(p4);
                
                
                Passo p5 = new Passo();
                p5.receitaId = 1;
                p5.descricao = "Envolva as claras com o creme de queijo";
                p5.tempoEsperado = TimeSpan.FromSeconds(30);
                p5.numeroSequencia = 5;
                p5.receita = r;
                
                context.passos.Add(p5);
                       
                Passo p6 = new Passo();
                p6.receitaId = 1;
                p6.descricao = "Numa taça, junte as duas colheres de sopa de açúcar, o brandy e o café";
                p6.tempoEsperado = TimeSpan.FromSeconds(30);
                p6.numeroSequencia = 6;
                p6.receita = r;
                
                IngredientePasso i6_1 = new IngredientePasso(acucar, p6, 2, "colheres de sopa");
               // p6.ingredientes.Add(i6_1);
                IngredientePasso i6_2 = new IngredientePasso(brandy, p6, 90 , "ml");
              //  p6.ingredientes.Add(i6_2);
                IngredientePasso i6_3 = new IngredientePasso(cafe, p6, 5 , "l");
             //   p6.ingredientes.Add(i6_3);

                
                context.passos.Add(p6);
                context.ingredientesPassos.Add(i6_1);
                context.ingredientesPassos.Add(i6_2);
                context.ingredientesPassos.Add(i6_3);
                
                Passo p7 = new Passo();
                p7.receitaId = 1;
                p7.descricao = "Misture tudo";
                p7.tempoEsperado = TimeSpan.FromSeconds(30);
                p7.numeroSequencia = 7;
                p7.receita = r;
                
                context.passos.Add(p7);
                
                
                Passo p8 = new Passo();
                p8.receitaId = 1;
                p8.descricao = "Passe os palitos de champanhe pelo café";
                p8.tempoEsperado = TimeSpan.FromSeconds(30);
                p8.numeroSequencia = 8;
                p8.receita = r;
                
                IngredientePasso i8 = new IngredientePasso(champanhe, p8, 350, "gramas");
              //  p8.ingredientes.Add(i8);

                
                context.passos.Add(p8);
                context.ingredientesPassos.Add(i8);
                
                Passo p9 = new Passo();
                p9.receitaId = 1;
                p9.descricao = "Espalhe metade dos palitos no fundo de um tabuleiro rectangular";
                p9.tempoEsperado = TimeSpan.FromSeconds(30);
                p9.numeroSequencia = 9;
                p9.receita = r;
                
                context.passos.Add(p9);
                
                Passo p10 = new Passo();
                p10.receitaId = 1;
                p10.descricao = "Por cima, espalhe metade do creme";
                p10.tempoEsperado = TimeSpan.FromSeconds(30);
                p10.numeroSequencia = 10;
                p10.receita = r;
                
                context.passos.Add(p10);
                
                Passo p11 = new Passo();
                p11.receitaId = 1;
                p11.descricao = "Com a ajuda de um passador de rede, espalhe um pouco de cacau por cima";
                p11.tempoEsperado = TimeSpan.FromSeconds(30);
                p11.numeroSequencia = 11;
                p11.receita = r;
                
                IngredientePasso i11 = new IngredientePasso(cacau, p11, 1, "qb");
              //  p11.ingredientes.Add(i11);
                
                context.passos.Add(p11);
                context.ingredientesPassos.Add(i11);
                
                Passo p12 = new Passo();
                p12.receitaId = 1;
                p12.descricao = "Por cima, volte a repetir o processo, com os restantes palitos de champanhe embebidos em café";
                p12.tempoEsperado = TimeSpan.FromSeconds(30);
                p12.numeroSequencia = 12;
                p12.receita = r;
                
                context.passos.Add(p12);
                
                Passo p13 = new Passo();
                p13.receitaId = 1;
                p13.descricao = "Por cima, espalhe a outra metade do creme";
                p13.tempoEsperado = TimeSpan.FromSeconds(30);
                p13.numeroSequencia = 13;
                p13.receita = r;
                
                context.passos.Add(p13);
                
                Passo p14 = new Passo();
                p14.receitaId = 1;
                p14.descricao = "Por fim, polvilhe com o cacau";
                p14.tempoEsperado = TimeSpan.FromSeconds(30);
                p14.numeroSequencia = 14;
                p14.receita = r;
                
                context.passos.Add(p14);
                
                Passo p15 = new Passo();
                p15.receitaId = 1;
                p15.descricao = "Leve ao frigorífico durante 4 horas até ficar bem fresquinho.Depois de frio está pronto a servir";
                p15.tempoEsperado = TimeSpan.FromSeconds(30);
                p15.numeroSequencia = 15;
                p15.receita = r;
                
                context.passos.Add(p15);
                
                r.passos.Add(p1);
                r.passos.Add(p2);
                r.passos.Add(p3);
                r.passos.Add(p4);
                r.passos.Add(p5);
                r.passos.Add(p6);
                r.passos.Add(p7);
                r.passos.Add(p8);
                r.passos.Add(p9);
                r.passos.Add(p10);
                r.passos.Add(p11);
                r.passos.Add(p12);
                r.passos.Add(p13);
                r.passos.Add(p14);
                r.passos.Add(p15);
                context.receitas.Add(r);
                context.SaveChanges();
                
            }
        }
    }
}
