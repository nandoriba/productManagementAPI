CREATE TABLE Categoria (
    Id uniqueidentifier NOT NULL,
    Nome varchar(100) NOT NULL,
    Situacao int NOT NULL,
    CONSTRAINT PK_Categoria PRIMARY KEY (Id)
);

CREATE TABLE Produto (
    Id uniqueidentifier NOT NULL,
    Nome varchar(100) NOT NULL,
    Descricao varchar(500) NOT NULL,
    Preco decimal(18,2) NOT NULL,
    Situacao int NOT NULL,
    CONSTRAINT PK_Produto PRIMARY KEY (Id)
);

CREATE TABLE AssociacaoProdutoCategoria (
    Id uniqueidentifier NOT NULL,
    CategoriaId uniqueidentifier NOT NULL,
    ProdutoId uniqueidentifier NOT NULL,
    CONSTRAINT PK_AssociacaoProdutoCategoria PRIMARY KEY (Id),
    CONSTRAINT FK_AssociacaoProdutoCategoria_Categoria FOREIGN KEY (CategoriaId) REFERENCES Categoria(Id),
    CONSTRAINT FK_AssociacaoProdutoCategoria_Produto FOREIGN KEY (ProdutoId) REFERENCES Produto(Id)
);
