ALTER TABLE Receita DROP CONSTRAINT FKReceita791421;
ALTER TABLE Passo DROP CONSTRAINT FKPasso712365;
ALTER TABLE IngredientePasso DROP CONSTRAINT FKIngredient454804;
ALTER TABLE IngredientePasso DROP CONSTRAINT FKIngredient977960;
ALTER TABLE Ementa_Semanal DROP CONSTRAINT FKEmenta_Sem592369;
ALTER TABLE Ementa_Semanal DROP CONSTRAINT FKEmenta_Sem958079;
ALTER TABLE Avaliacao DROP CONSTRAINT FKAvaliacao262174;
ALTER TABLE Confecao DROP CONSTRAINT FKConfecao216716;
ALTER TABLE Confecao DROP CONSTRAINT FKConfecao417573;
ALTER TABLE ConfecaoPasso DROP CONSTRAINT FKConfecaoPa949582;
ALTER TABLE ConfecaoPasso DROP CONSTRAINT FKConfecaoPa437573;
DROP TABLE Avaliacao;
DROP TABLE Confecao;
DROP TABLE ConfecaoPasso;
DROP TABLE Ementa_Semanal;
DROP TABLE Ingrediente;
DROP TABLE IngredientePasso;
DROP TABLE Passo;
DROP TABLE Receita;
DROP TABLE Temperatura;
DROP TABLE Utilizador;
