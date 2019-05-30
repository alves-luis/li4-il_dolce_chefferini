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
                    "O tiramissí é uma sobremesa italiana, possivelmente originária da cidade de Treviso, na região do Vêneto e que consiste em camadas de biscoitos de champagne entremeadas por um creme doce";
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

                r.passos.Add(p1);
                context.receitas.Add(r);
                context.SaveChanges();
                
            }
        }
    }
}