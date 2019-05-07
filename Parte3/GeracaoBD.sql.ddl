CREATE TABLE Avaliacao (
  confecaoId      int NOT NULL, 
  dificuldade     int NOT NULL, 
  utilidadeAjudas int NULL, 
  grauSatisfacao  int NOT NULL, 
  data            datetime NOT NULL, 
  PRIMARY KEY (confecaoId));
CREATE TABLE Confecao (
  id           int IDENTITY NOT NULL, 
  usouAjuda    bit DEFAULT '0' NOT NULL, 
  bemSucedida  bit DEFAULT '0' NOT NULL, 
  receitaId    int NOT NULL, 
  utilizadorId int NOT NULL, 
  PRIMARY KEY (id));
CREATE TABLE ConfecaoPasso (
  confecaoId           int NOT NULL, 
  receitaId            int NOT NULL, 
  numeroSequenciaPasso int NOT NULL, 
  tempoEmTicks         int NOT NULL, 
  PRIMARY KEY (confecaoId, 
  receitaId, 
  numeroSequenciaPasso));
CREATE TABLE Ementa_Semanal (
  diaDaSemana  varchar(64) NOT NULL, 
  almoco       bit NOT NULL, 
  utilizadorId int NOT NULL, 
  receitaId    int NOT NULL, 
  PRIMARY KEY (diaDaSemana, 
  almoco, 
  utilizadorId));
CREATE TABLE Ingrediente (
  id     int NOT NULL, 
  nome   varchar(255) NOT NULL, 
  imagem varchar(128) NULL, 
  comida bit NOT NULL, 
  PRIMARY KEY (id));
CREATE TABLE IngredientePasso (
  ingredienteId        int NOT NULL, 
  receitaId            int NOT NULL, 
  numeroSequenciaPasso int NOT NULL, 
  quantidade           int NOT NULL, 
  unidade              varchar(32) NOT NULL, 
  PRIMARY KEY (ingredienteId, 
  receitaId, 
  numeroSequenciaPasso));
CREATE TABLE Passo (
  numeroSequencia      int NOT NULL, 
  receitaId            int NOT NULL, 
  descricao            varchar(255) NOT NULL, 
  tempoEsperadoEmTicks int NOT NULL, 
  aspetoEsperado       varchar(128) NOT NULL, 
  PRIMARY KEY (numeroSequencia, 
  receitaId));
CREATE TABLE Receita (
  id                   int NOT NULL, 
  nome                 varchar(255) NOT NULL, 
  descricao            varchar(511) NOT NULL, 
  tempoEsperadoEmTicks int NOT NULL, 
  grauDificuldade      int NOT NULL, 
  doses                int NOT NULL, 
  temperaturaId        int NOT NULL, 
  calorias             int NOT NULL, 
  lipidos              int NOT NULL, 
  hidratos             int NOT NULL, 
  proteinas            int NOT NULL, 
  criador              varchar(64) NOT NULL, 
  PRIMARY KEY (id));
CREATE TABLE Temperatura (
  id   int IDENTITY NOT NULL, 
  nome varchar(255) NOT NULL, 
  PRIMARY KEY (id));
CREATE TABLE Utilizador (
  id       int NOT NULL, 
  email    varchar(64) NOT NULL, 
  password varchar(64) NOT NULL, 
  PRIMARY KEY (id));
ALTER TABLE Receita ADD CONSTRAINT FKReceita791421 FOREIGN KEY (temperaturaId) REFERENCES Temperatura (id);
ALTER TABLE Passo ADD CONSTRAINT FKPasso712365 FOREIGN KEY (receitaId) REFERENCES Receita (id);
ALTER TABLE IngredientePasso ADD CONSTRAINT FKIngredient454804 FOREIGN KEY (ingredienteId) REFERENCES Ingrediente (id);
ALTER TABLE IngredientePasso ADD CONSTRAINT FKIngredient977960 FOREIGN KEY (numeroSequenciaPasso, receitaId) REFERENCES Passo (numeroSequencia, receitaId);
ALTER TABLE Ementa_Semanal ADD CONSTRAINT FKEmenta_Sem592369 FOREIGN KEY (receitaId) REFERENCES Receita (id);
ALTER TABLE Ementa_Semanal ADD CONSTRAINT FKEmenta_Sem958079 FOREIGN KEY (utilizadorId) REFERENCES Utilizador (id);
ALTER TABLE Avaliacao ADD CONSTRAINT FKAvaliacao262174 FOREIGN KEY (confecaoId) REFERENCES Confecao (id);
ALTER TABLE Confecao ADD CONSTRAINT FKConfecao216716 FOREIGN KEY (receitaId) REFERENCES Receita (id);
ALTER TABLE Confecao ADD CONSTRAINT FKConfecao417573 FOREIGN KEY (utilizadorId) REFERENCES Utilizador (id);
ALTER TABLE ConfecaoPasso ADD CONSTRAINT FKConfecaoPa949582 FOREIGN KEY (confecaoId) REFERENCES Confecao (id);
ALTER TABLE ConfecaoPasso ADD CONSTRAINT FKConfecaoPa437573 FOREIGN KEY (numeroSequenciaPasso, receitaId) REFERENCES Passo (numeroSequencia, receitaId);

