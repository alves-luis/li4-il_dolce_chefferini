using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Il_Dolce_Chefferini.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingrediente",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(maxLength: 255, nullable: false),
                    comida = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrediente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Temperatura",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperatura", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Utilizador",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    email = table.Column<string>(maxLength: 64, nullable: false),
                    password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizador", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Receita",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(maxLength: 255, nullable: false),
                    descricao = table.Column<string>(maxLength: 511, nullable: false),
                    tempoEsperadoEmTicks = table.Column<long>(nullable: false),
                    grauDificuldade = table.Column<int>(nullable: false),
                    calorias = table.Column<int>(nullable: false),
                    lipidos = table.Column<int>(nullable: false),
                    hidratos = table.Column<int>(nullable: false),
                    proteinas = table.Column<int>(nullable: false),
                    doses = table.Column<int>(nullable: false),
                    criador = table.Column<string>(maxLength: 64, nullable: false),
                    temperaturaId = table.Column<int>(nullable: false),
                    imagem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receita", x => x.id);
                    table.ForeignKey(
                        name: "FK_Receita_Temperatura_temperaturaId",
                        column: x => x.temperaturaId,
                        principalTable: "Temperatura",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Confecao",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    usouAjuda = table.Column<bool>(nullable: false),
                    bemSucedida = table.Column<bool>(nullable: false),
                    utilizadorId = table.Column<int>(nullable: false),
                    receitaId = table.Column<int>(nullable: false),
                    passoAtual = table.Column<int>(nullable: false),
                    inicioPassoAtual = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confecao", x => x.id);
                    table.ForeignKey(
                        name: "FK_Confecao_Receita_receitaId",
                        column: x => x.receitaId,
                        principalTable: "Receita",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Confecao_Utilizador_utilizadorId",
                        column: x => x.utilizadorId,
                        principalTable: "Utilizador",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ementa",
                columns: table => new
                {
                    utilizadorId = table.Column<int>(nullable: false),
                    diaDaSemana = table.Column<string>(maxLength: 64, nullable: false),
                    almoco = table.Column<bool>(nullable: false),
                    receitaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ementa", x => new { x.almoco, x.utilizadorId, x.diaDaSemana });
                    table.ForeignKey(
                        name: "FK_Ementa_Receita_receitaId",
                        column: x => x.receitaId,
                        principalTable: "Receita",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ementa_Utilizador_utilizadorId",
                        column: x => x.utilizadorId,
                        principalTable: "Utilizador",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Passo",
                columns: table => new
                {
                    receitaId = table.Column<int>(nullable: false),
                    numeroSequencia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descricao = table.Column<string>(maxLength: 255, nullable: false),
                    urlVideo = table.Column<string>(maxLength: 512, nullable: true),
                    tempoEsperadoEmTicks = table.Column<long>(nullable: false),
                    aspetoEsperado = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passo", x => new { x.receitaId, x.numeroSequencia });
                    table.ForeignKey(
                        name: "FK_Passo_Receita_receitaId",
                        column: x => x.receitaId,
                        principalTable: "Receita",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    confecaoId = table.Column<int>(nullable: false),
                    dificuldade = table.Column<int>(nullable: false),
                    utilidadeAjudas = table.Column<int>(nullable: true),
                    grauSatisfacao = table.Column<int>(nullable: false),
                    data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.confecaoId);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Confecao_confecaoId",
                        column: x => x.confecaoId,
                        principalTable: "Confecao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConfecaoPasso",
                columns: table => new
                {
                    confecaoId = table.Column<int>(nullable: false),
                    numeroSequenciaPasso = table.Column<int>(nullable: false),
                    receitaId = table.Column<int>(nullable: false),
                    tempoEmTicks = table.Column<long>(nullable: false),
                    passoreceitaId = table.Column<int>(nullable: true),
                    passonumeroSequencia = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfecaoPasso", x => new { x.confecaoId, x.numeroSequenciaPasso, x.receitaId });
                    table.ForeignKey(
                        name: "FK_ConfecaoPasso_Confecao_confecaoId",
                        column: x => x.confecaoId,
                        principalTable: "Confecao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfecaoPasso_Passo_passoreceitaId_passonumeroSequencia",
                        columns: x => new { x.passoreceitaId, x.passonumeroSequencia },
                        principalTable: "Passo",
                        principalColumns: new[] { "receitaId", "numeroSequencia" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IngredientePasso",
                columns: table => new
                {
                    receitaId = table.Column<int>(nullable: false),
                    numeroSequenciaPasso = table.Column<int>(nullable: false),
                    ingredienteId = table.Column<int>(nullable: false),
                    quantidade = table.Column<int>(nullable: false),
                    unidade = table.Column<string>(maxLength: 32, nullable: false),
                    passoreceitaId = table.Column<int>(nullable: true),
                    passonumeroSequencia = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientePasso", x => new { x.ingredienteId, x.receitaId, x.numeroSequenciaPasso });
                    table.ForeignKey(
                        name: "FK_IngredientePasso_Ingrediente_ingredienteId",
                        column: x => x.ingredienteId,
                        principalTable: "Ingrediente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientePasso_Passo_passoreceitaId_passonumeroSequencia",
                        columns: x => new { x.passoreceitaId, x.passonumeroSequencia },
                        principalTable: "Passo",
                        principalColumns: new[] { "receitaId", "numeroSequencia" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Confecao_receitaId",
                table: "Confecao",
                column: "receitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Confecao_utilizadorId",
                table: "Confecao",
                column: "utilizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfecaoPasso_passoreceitaId_passonumeroSequencia",
                table: "ConfecaoPasso",
                columns: new[] { "passoreceitaId", "passonumeroSequencia" });

            migrationBuilder.CreateIndex(
                name: "IX_Ementa_receitaId",
                table: "Ementa",
                column: "receitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ementa_utilizadorId",
                table: "Ementa",
                column: "utilizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientePasso_passoreceitaId_passonumeroSequencia",
                table: "IngredientePasso",
                columns: new[] { "passoreceitaId", "passonumeroSequencia" });

            migrationBuilder.CreateIndex(
                name: "IX_Receita_temperaturaId",
                table: "Receita",
                column: "temperaturaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "ConfecaoPasso");

            migrationBuilder.DropTable(
                name: "Ementa");

            migrationBuilder.DropTable(
                name: "IngredientePasso");

            migrationBuilder.DropTable(
                name: "Confecao");

            migrationBuilder.DropTable(
                name: "Ingrediente");

            migrationBuilder.DropTable(
                name: "Passo");

            migrationBuilder.DropTable(
                name: "Utilizador");

            migrationBuilder.DropTable(
                name: "Receita");

            migrationBuilder.DropTable(
                name: "Temperatura");
        }
    }
}
