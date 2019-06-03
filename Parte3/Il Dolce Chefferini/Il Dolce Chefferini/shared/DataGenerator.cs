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
                Ingrediente champanhe = new Ingrediente(1, "Palitos de Champanhe", true);
                Ingrediente mascarpone = new Ingrediente(2, "Queijo Mascarpone", true);
                Ingrediente ovo = new Ingrediente(3, "Ovos", true);
                Ingrediente cafe = new Ingrediente(4, "Café", true);
                Ingrediente acucar = new Ingrediente(5, "Açúcar", true);
                Ingrediente brandy = new Ingrediente(6, "Brandy", true);
                Ingrediente cacau = new Ingrediente(7, "Cacau", true);
                Ingrediente taca = new Ingrediente(8, "Taça", false);
                Ingrediente clara = new Ingrediente(9, "Clara", true);
                Ingrediente gema = new Ingrediente(10, "Gema", true);
                Ingrediente batedeira = new Ingrediente(11, "Batedeira", false);
                Ingrediente colher = new Ingrediente(12, "Colher", false);
                Ingrediente tabuleiro = new Ingrediente(13, "Tabuleiro retangular", false);
                Ingrediente peneira = new Ingrediente(14, "Peneira", false);
                Ingrediente frigorifico = new Ingrediente(15, "Frigorífico", false);
                context.ingredientes.Add(champanhe);
                context.ingredientes.Add(mascarpone);
                context.ingredientes.Add(ovo);
                context.ingredientes.Add(cafe);
                context.ingredientes.Add(acucar);
                context.ingredientes.Add(brandy);
                context.ingredientes.Add(cacau);
                context.ingredientes.Add(taca);
                context.ingredientes.Add(clara);
                context.ingredientes.Add(gema);
                context.ingredientes.Add(batedeira);
                context.ingredientes.Add(colher);
                context.ingredientes.Add(tabuleiro);
                context.ingredientes.Add(peneira);
                context.ingredientes.Add(frigorifico);

                Temperatura t = new Temperatura();
                t.id = 1;
                t.nome = "Fria";
                context.temperaturas.Add(t);

                Receita r = new Receita();
                r.nome = "Tiramisú";
                r.descricao =
                    "O Tiramisú é uma sobremesa italiana, possivelmente originária da cidade de Treviso, na região do Veneto e que consiste em camadas de biscoitos de champagne entremeadas por um creme doce.";
                r.doses = 10;
                r.tempoEsperado = TimeSpan.FromHours(4.5);
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
                p1.urlVideo = "https://www.youtube.com/embed/tx72s86URhA";


                IngredientePasso i1 = new IngredientePasso(ovo, p1, 6, "unitário");
                
                context.passos.Add(p1);
                context.ingredientesPassos.Add(i1);
                
                Passo p2 = new Passo();
                p2.receitaId = 1;
                p2.descricao = "Numa taça, junte os 180g de açúcar às gemas e bata até ficar uma gemada esbranquiçada";
                p2.tempoEsperado = TimeSpan.FromSeconds(180);
                p2.numeroSequencia = 2;
                p2.receita = r;
                p2.aspetoEsperado = "pictures/passo2.jpg";
                p2.urlVideo = null;

                IngredientePasso i2_1 = new IngredientePasso(acucar, p2, 180, "gramas");
                IngredientePasso i2_2 = new IngredientePasso(gema, p2, 6, "unitário");
                IngredientePasso i2_3 = new IngredientePasso(taca, p2, 1, "unitário");
                IngredientePasso i2_4 = new IngredientePasso(batedeira, p2, 1, "unitário");


                context.passos.Add(p2);
                context.ingredientesPassos.Add(i2_1);
                context.ingredientesPassos.Add(i2_2);
                context.ingredientesPassos.Add(i2_3);
                context.ingredientesPassos.Add(i2_4);

                Passo p3 = new Passo();
                p3.receitaId = 1;
                p3.descricao = "Junte o queijo à mistura do passo anterior e bata tudo até ficar um creme liso";
                p3.tempoEsperado = TimeSpan.FromSeconds(180);
                p3.numeroSequencia = 3;
                p3.receita = r;
                p3.aspetoEsperado = "pictures/passo3.jpg";
                p3.urlVideo = null;

                IngredientePasso i3_1 = new IngredientePasso(mascarpone, p3, 600, "gramas");
                IngredientePasso i3_2 = new IngredientePasso(batedeira, p3, 1, "unitário");

                context.passos.Add(p3);
                context.ingredientesPassos.Add(i3_1);
                context.ingredientesPassos.Add(i3_2);

                Passo p4 = new Passo();
                p4.receitaId = 1;
                p4.descricao = "Numa nova taça, bata as claras em castelo";
                p4.tempoEsperado = TimeSpan.FromSeconds(90);
                p4.numeroSequencia = 4;
                p4.receita = r;
                p4.aspetoEsperado = "pictures/passo4.jpg";
                p4.urlVideo = "https://www.youtube.com/embed/wDfRr3HwpEA";

                IngredientePasso i4_1 = new IngredientePasso(clara, p4, 6, "unitário");
                IngredientePasso i4_2 = new IngredientePasso(taca, p4, 1, "unitário");
                IngredientePasso i4_3 = new IngredientePasso(batedeira, p4, 1, "unitário");

                context.passos.Add(p4);
                context.ingredientesPassos.Add(i4_1);
                context.ingredientesPassos.Add(i4_2);
                context.ingredientesPassos.Add(i4_3);


                Passo p5 = new Passo();
                p5.receitaId = 1;
                p5.descricao = "Misture as claras com o creme de queijo, adicionando duas colheres de claras de cada vez";
                p5.tempoEsperado = TimeSpan.FromSeconds(60);
                p5.numeroSequencia = 5;
                p5.receita = r;
                p5.aspetoEsperado = "pictures/passo5.jpg";
                p5.urlVideo = null;

                IngredientePasso i5 = new IngredientePasso(colher, p5, 1, "unitário");

                context.passos.Add(p5);
                context.ingredientesPassos.Add(i5);

                Passo p6 = new Passo();
                p6.receitaId = 1;
                p6.descricao = "Numa taça diferente, junte as duas colheres de sopa de açúcar, o brandy, o café";
                p6.tempoEsperado = TimeSpan.FromSeconds(30);
                p6.numeroSequencia = 6;
                p6.receita = r;
                p6.aspetoEsperado = "pictures/passo6.jpg";
                p6.urlVideo = null;

                IngredientePasso i6_1 = new IngredientePasso(acucar, p6, 2, "colheres de sopa");
                IngredientePasso i6_2 = new IngredientePasso(brandy, p6, 90 , "ml");
                IngredientePasso i6_3 = new IngredientePasso(cafe, p6, 500 , "ml");
                IngredientePasso i6_4 = new IngredientePasso(taca, p6, 1, "unitário");


                context.passos.Add(p6);
                context.ingredientesPassos.Add(i6_1);
                context.ingredientesPassos.Add(i6_2);
                context.ingredientesPassos.Add(i6_3);
                context.ingredientesPassos.Add(i6_4);

                Passo p7 = new Passo();
                p7.receitaId = 1;
                p7.descricao = "Com uma colher, mexa os ingredientes do passo anterior";
                p7.tempoEsperado = TimeSpan.FromSeconds(30);
                p7.numeroSequencia = 7;
                p7.receita = r;
                p7.aspetoEsperado = "pictures/passo7.jpg";
                p7.urlVideo = null;

                IngredientePasso i7 = new IngredientePasso(colher, p7, 1, "unitário");

                context.passos.Add(p7);
                context.ingredientesPassos.Add(i7);


                Passo p8 = new Passo();
                p8.receitaId = 1;
                p8.descricao = "Mergulhe cada palito de champanhe no café durante 2 segundos na mistura do passo anterior.";
                p8.tempoEsperado = TimeSpan.FromSeconds(60);
                p8.numeroSequencia = 8;
                p8.receita = r;
                p8.aspetoEsperado = "pictures/passo8.jpg";
                p8.urlVideo = null;

                IngredientePasso i8 = new IngredientePasso(champanhe, p8, 350, "gramas");

                context.passos.Add(p8);
                context.ingredientesPassos.Add(i8);
                
                Passo p9 = new Passo();
                p9.receitaId = 1;
                p9.descricao = "Espalhe metade dos palitos no fundo de um tabuleiro rectangular";
                p9.tempoEsperado = TimeSpan.FromSeconds(50);
                p9.numeroSequencia = 9;
                p9.receita = r;
                p9.aspetoEsperado = "pictures/passo9.jpg";
                p9.urlVideo = null;

                IngredientePasso i9 = new IngredientePasso(tabuleiro, p9, 1, "unitário");

                context.passos.Add(p9);
                context.ingredientesPassos.Add(i9);


                Passo p10 = new Passo();
                p10.receitaId = 1;
                p10.descricao = "Por cima dos palitos, espalhe metade do creme";
                p10.tempoEsperado = TimeSpan.FromSeconds(30);
                p10.numeroSequencia = 10;
                p10.receita = r;
                p10.aspetoEsperado = "pictures/passo10.jpg";
                p10.urlVideo = null;

                IngredientePasso i10 = new IngredientePasso(colher, p10, 1, "unitário");
                context.passos.Add(p10);
                context.ingredientesPassos.Add(i10);


                Passo p11 = new Passo();
                p11.receitaId = 1;
                p11.descricao = "Com a ajuda de uma peneira, espalhe o cacau por cima do creme";
                p11.tempoEsperado = TimeSpan.FromSeconds(30);
                p11.numeroSequencia = 11;
                p11.receita = r;
                p11.aspetoEsperado = "pictures/passo11.jpg";
                p11.urlVideo = null;

                IngredientePasso i11_1 = new IngredientePasso(cacau, p11, 150, "g");
                IngredientePasso i11_2 = new IngredientePasso(peneira, p11, 1, "unitário");

                context.passos.Add(p11);
                context.ingredientesPassos.Add(i11_1);
                context.ingredientesPassos.Add(i11_2);


                Passo p12 = new Passo();
                p12.receitaId = 1;
                p12.descricao = "Por cima, volte a repetir o processo, com os restantes palitos de champanhe embebidos em café";
                p12.tempoEsperado = TimeSpan.FromSeconds(30);
                p12.numeroSequencia = 12;
                p12.receita = r;
                p12.aspetoEsperado = "pictures/passo12.jpg";
                p12.urlVideo = null;

                context.passos.Add(p12);
                
                Passo p13 = new Passo();
                p13.receitaId = 1;
                p13.descricao = "Por cima, espalhe a outra metade do creme";
                p13.tempoEsperado = TimeSpan.FromSeconds(30);
                p13.numeroSequencia = 13;
                p13.receita = r;
                p13.aspetoEsperado = "pictures/passo13.jpg";
                p13.urlVideo = null;

                IngredientePasso i13 = new IngredientePasso(colher, p13, 1, "unitário");
                context.passos.Add(p13);
                context.ingredientesPassos.Add(i13);


                Passo p14 = new Passo();
                p14.receitaId = 1;
                p14.descricao = "Por fim, polvilhe com o cacau";
                p14.tempoEsperado = TimeSpan.FromSeconds(30);
                p14.numeroSequencia = 14;
                p14.receita = r;
                p14.aspetoEsperado = "pictures/passo14.jpg";
                p14.urlVideo = null;

                IngredientePasso i14_1 = new IngredientePasso(cacau, p14, 150, "g");
                IngredientePasso i14_2 = new IngredientePasso(peneira, p14, 1, "unitário");

                context.passos.Add(p14);
                context.ingredientesPassos.Add(i14_1);
                context.ingredientesPassos.Add(i14_2);


                Passo p15 = new Passo();
                p15.receitaId = 1;
                p15.descricao = "Leve ao frigorífico durante 4 horas até ficar bem fresquinho. Depois de frio está pronto a servir";
                p15.tempoEsperado = TimeSpan.FromHours(4);
                p15.numeroSequencia = 15;
                p15.receita = r;
                p15.aspetoEsperado = "pictures/passo15.jpg";
                p15.urlVideo = null;

                IngredientePasso i15 = new IngredientePasso(frigorifico, p15, 1, "unitário");

                context.passos.Add(p15);
                context.ingredientesPassos.Add(i15);





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
                
                
                Utilizador u1 = new Utilizador();
                context.utilizadores.Add(u1);
                
                context.SaveChanges();
                
            }
        }
    }
}
