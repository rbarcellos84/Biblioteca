CREATE TABLE Autor (
    IdAutor int NOT NULL IDENTITY,
    Nome nvarchar (100) NOT NULL,
    PRIMARY KEY (IdAutor)
)
GO
CREATE TABLE Livro (
    IdLivro int NOT NULL IDENTITY,
    Titulo nvarchar (100) NOT NULL,
    Genero nvarchar (50) NOT NULL,
    Resumo nvarchar (250) NOT NULL,
    Foto nvarchar (500) NOT NULL,
    IdAutor int NOT NULL,
    IdEditora int NOT NULL,
    PRIMARY KEY (IdLivro)
)
GO
CREATE TABLE Editora (
    IdEditora int NOT NULL IDENTITY,
    Nome nvarchar (100) NOT NULL,
    PRIMARY KEY (IdEditora)
)
GO