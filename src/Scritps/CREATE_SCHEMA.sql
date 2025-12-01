CREATE DATABASE [DevLearning]
GO

USE [DevLearning]
GO

CREATE TABLE [Student]
(
    [Id] uniqueidentifier NOT NULL,
    [Name] NVARCHAR(120) NOT NULL,
    [Email] NVARCHAR(180) NOT NULL,
    [Document] NVARCHAR(20) NULL,
    [Phone] NVARCHAR(20) NULL,
    [Birthdate] DATETIME NULL,
    [CreateDate] DATETIME NOT NULL DEFAULT(GETDATE()),
    CONSTRAINT [PK_Student] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Author]
(
    [Id] uniqueidentifier NOT NULL,
    [Name] NVARCHAR(80) NOT NULL,
    [Title] NVARCHAR(80) NOT NULL,
    [Image] NVARCHAR(1024) NOT NULL,
    [Bio] NVARCHAR(2000) NOT NULL,
    [Url] nvarchar(450) NULL,
    [Email] NVARCHAR(160) NOT NULL,
    [Type] TINYINT NOT NULL,
    CONSTRAINT [PK_Author] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Career]
(
    [Id] uniqueidentifier NOT NULL,
    [Title] NVARCHAR(160) NOT NULL,
    [Summary] NVARCHAR(2000) NOT NULL,
    [Url] NVARCHAR(1024) NOT NULL,
    [DurationInMinutes] INT NOT NULL,
    [Active] BIT NOT NULL,
    [Featured] BIT NOT NULL,
    [Tags] NVARCHAR(160) NOT NULL,
    CONSTRAINT [PK_Career] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Category]
(
    [Id] uniqueidentifier NOT NULL,
    [Title] NVARCHAR(160) NOT NULL,
    [Url] NVARCHAR(1024) NOT NULL,
    [Summary] NVARCHAR(2000) NOT NULL,
    [Order] int NOT NULL,
    [Description] TEXT NOT NULL,
    [Featured] BIT NOT NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Course]
(
    [Id] uniqueidentifier NOT NULL,
    [Tag] NVARCHAR(20) NOT NULL,
    [Title] NVARCHAR(160) NOT NULL,
    [Summary] NVARCHAR(2000) NOT NULL,
    [Url] NVARCHAR(1024) NOT NULL,
    [Level] TINYINT NOT NULL,
    [DurationInMinutes] INT NOT NULL,
    [CreateDate] DATETIME NOT NULL,
    [LastUpdateDate] DATETIME NOT NULL,
    [Active] BIT NOT NULL,
    [Free] BIT NOT NULL,
    [Featured] BIT NOT NULL,
    [AuthorId] uniqueidentifier NOT NULL,
    [CategoryId] uniqueidentifier NOT NULL,
    [Tags] NVARCHAR(160) NOT NULL,
    CONSTRAINT [PK_Course] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Course_Author_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Author] ([Id]),
    CONSTRAINT [FK_Course_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id])
);
GO

CREATE TABLE [CareerItem]
(
    [CareerId] uniqueidentifier NOT NULL,
    [CourseId] uniqueidentifier NOT NULL,
    [Title] NVARCHAR(160) NOT NULL,
    [Description] TEXT NOT NULL,
    [Order] TINYINT NOT NULL,
    
    CONSTRAINT [PK_CareerItem] PRIMARY KEY ([CourseId], [CareerId]),
    CONSTRAINT [FK_CareerItem_Career_CareerId] FOREIGN KEY ([CareerId]) REFERENCES [Career] ([Id]),
    CONSTRAINT [FK_CareerItem_Course_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Course] ([Id])
);
GO

CREATE TABLE [StudentCourse]
(
    [CourseId] uniqueidentifier NOT NULL,
    [StudentId] uniqueidentifier NOT NULL,
    [Progress] TINYINT NOT NULL,
    [Favorite] BIT NOT NULL,
    [StartDate] DATETIME NOT NULL,
    [LastUpdateDate] DATETIME NULL DEFAULT(GETDATE()),
    CONSTRAINT [PK_StudentCourse] PRIMARY KEY ([CourseId], [StudentId]),
    CONSTRAINT [FK_StudentCourse_Course_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Course] ([Id]),
    CONSTRAINT [FK_StudentCourse_Student_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [Student] ([Id])
);
GO

INSERT INTO [dbo].[Author] 
    ([Id], [Name], [Title], [Image], [Bio], [Url], [Email], [Type]) 
VALUES
    -- Autor do Curso de C#
    ('8A1C5D9F-2B3E-4A5C-6D7E-8F9A0B1C2D3E', 'Gustavo', 'Microsoft MVP', 'imagem-4k', 'Apaixonado por ensino e .NET', 'gustavo', 'gustavo@devlearning.com', 1),

    -- Autor do Curso de APIs
    ('B2C3D4E5-F6A7-8B9C-0D1E-2F3A4B5C6D7E', 'Virgínia', 'Tech Lead', 'imagem-4k','Especialista em Web APIs e Cloud', 'virginia', 'virginia@devlearning.com', 1),

    -- Autor do Curso de SQL
    ('D3E4F5A6-B7C8-9D0E-1F2A-3B4C5D6E7F8A', 'Brent Ozar', 'SQL Master', 'imagem-4k', 'O mago da performance no SQL Server', 'brent-ozar', 'brent@sql.com', 0),

    -- Autor do Curso de F1 (Notei que você usou um ID diferente aqui, mantive o seu)
    ('09876543-2109-8765-4321-FEDCBA987654', 'Adrian Newey', 'Engenheiro Chefe', 'imagem-4k', 'Projetista de carros campeões', 'adrian-newey', 'newey@f1.com', 0),

    -- Autor do Curso de Arquitetura
    ('99887766-5544-3322-1100-AABBCCDDEEFF', 'Uncle Bob', 'Clean Coder', 'imagem-4k', 'Criador do SOLID e Clean Architecture', 'uncle-bob', 'bob@clean.com', 0);
GO

SELECT * FROM [Author]

SELECT TOP 10 *
FROM Course

SELECT TOP 10 *
FROM Author

SELECT TOP 10 *
FROM Category

INSERT INTO [dbo].[Category] 
    ([Id], [Title], [Url], [Summary], [Order], [Description], [Featured]) 
VALUES
    -- Usado no Curso de C#
    ('11223344-5566-7788-99AA-BBCCDDEEFF00', 'Fundamentos', 'fundamentos', 'Base da programação', 1, 'Cursos para iniciantes', 0),

    -- Usado no Curso de APIs
    ('C1D2E3F4-A5B6-7C8D-9E0F-1A2B3C4D5E6F', 'Backend', 'backend', 'Desenvolvimento Server-side', 2, 'APIs, Microsserviços e mais', 1),

    -- Usado no Curso de SQL
    ('E5F6A7B8-C9D0-1E2F-3A4B-5C6D7E8F9A0B', 'Banco de Dados', 'banco-de-dados', 'SQL e NoSQL', 3, 'Persistência e otimização', 0),

    -- Usado no Curso de F1
    ('AA11BB22-CC33-DD44-EE55-1234567890AB', 'Engenharia', 'engenharia', 'Física e Mecânica', 4, 'Engenharia aplicada', 1),

    -- Usado no Curso de Arquitetura
    ('1234ABCD-5678-EF90-1234-567890ABCDEF', 'Arquitetura de Software', 'arquitetura', 'Padrões e Design', 5, 'Boas práticas de desenho de software', 1);
GO

-- 1. Curso de C# Básico
INSERT INTO [dbo].[Course]
    ([Id], [Tag], [Title], [Summary], [Url], [Level], [DurationInMinutes], [CreateDate], [LastUpdateDate], [Active], [Free], [Featured], [AuthorId], [CategoryId], [Tags])
VALUES
    ('7e9d4c21-b3a5-4f8e-9c1d-2a6b5e0f3d8a', 
    'CSHARP-01', 
    'Fundamentos do C# e .NET 9', 
    'Aprenda a sintaxe básica, orientação a objetos e como criar sua primeira aplicação console.', 
    'fundamentos-csharp-dotnet', 
    1, -- Nível Básico
    120, -- 2 horas
    GETDATE(), GETDATE(), 
    1, -- Ativo
    1, -- Gratuito
    0, -- Destaque
    '8A1C5D9F-2B3E-4A5C-6D7E-8F9A0B1C2D3E', '11223344-5566-7788-99AA-BBCCDDEEFF00', 
    'C#;.NET;Logic;Programming');

-- 2. Curso de APIs
INSERT INTO [dbo].[Course]
    ([Id], [Tag], [Title], [Summary], [Url], [Level], [DurationInMinutes], [CreateDate], [LastUpdateDate], [Active], [Free], [Featured], [AuthorId], [CategoryId], [Tags])
VALUES
    ('c4b1a2d3-e5f6-4789-8901-234567890abc', 
    'ASP-API', 
    'Construindo APIs REST com ASP.NET Core', 
    'Domine a criação de endpoints, injeção de dependência e conexão com banco de dados usando EF Core e Dapper.', 
    'apis-rest-aspnet-core', 
    2, -- Nível Intermediário
    360, -- 6 horas
    GETDATE(), GETDATE(), 
    1, -- Ativo
    0, -- Pago
    1, -- Destaque (Featured)
    'B2C3D4E5-F6A7-8B9C-0D1E-2F3A4B5C6D7E', 'C1D2E3F4-A5B6-7C8D-9E0F-1A2B3C4D5E6F', 
    'Backend;API;Web;REST');

-- 3. Curso de SQL e Performance
INSERT INTO [dbo].[Course]
    ([Id], [Tag], [Title], [Summary], [Url], [Level], [DurationInMinutes], [CreateDate], [LastUpdateDate], [Active], [Free], [Featured], [AuthorId], [CategoryId], [Tags])
VALUES
    ('f1e2d3c4-b5a6-7890-1234-567890abcdef', 
    'SQL-PERF', 
    'SQL Server: Performance e Otimização', 
    'Entenda como funcionam índices, planos de execução e como evitar queries lentas no seu sistema.', 
    'sql-server-performance', 
    3, -- Nível Avançado
    240, -- 4 horas
    GETDATE(), GETDATE(), 
    1, -- Ativo
    0, -- Pago
    0, -- Destaque
    'D3E4F5A6-B7C8-9D0E-1F2A-3B4C5D6E7F8A', 'E5F6A7B8-C9D0-1E2F-3A4B-5C6D7E8F9A0B', 
    'Database;SQL;Performance;Tuning');

-- 4. Curso de Fórmula 1 (Engenharia)
INSERT INTO [dbo].[Course]
    ([Id], [Tag], [Title], [Summary], [Url], [Level], [DurationInMinutes], [CreateDate], [LastUpdateDate], [Active], [Free], [Featured], [AuthorId], [CategoryId], [Tags])
VALUES
    ('a9b8c7d6-e5f4-3210-9876-543210fedcba', 
    'F1-ENG', 
    'Engenharia de Pista na F1', 
    'Como configurar o setup do carro, ajustes de asa e pressão de pneus para diferentes circuitos.', 
    'engenharia-pista-f1', 
    3, -- Nível Avançado
    180, -- 3 horas
    GETDATE(), GETDATE(), 
    1, -- Ativo
    0, -- Pago
    1, -- Destaque
    '09876543-2109-8765-4321-FEDCBA987654', 'AA11BB22-CC33-DD44-EE55-1234567890AB', 
    'F1;Engineering;Setup;Physics');

-- 5. Curso de Arquitetura de Software
INSERT INTO [dbo].[Course]
    ([Id], [Tag], [Title], [Summary], [Url], [Level], [DurationInMinutes], [CreateDate], [LastUpdateDate], [Active], [Free], [Featured], [AuthorId], [CategoryId], [Tags])
VALUES
    ('1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d', 
    'ARCH-CLEAN', 
    'Clean Architecture Descomplicada', 
    'Aprenda a separar seu projeto em camadas de Domínio, Aplicação e Infraestrutura para facilitar testes e manutenção.', 
    'clean-architecture-descomplicada', 
    2, -- Nível Intermediário
    420, -- 7 horas
    GETDATE(), GETDATE(), 
    1, -- Ativo
    0, -- Pago
    1, -- Destaque
    '99887766-5544-3322-1100-AABBCCDDEEFF', '1234ABCD-5678-EF90-1234-567890ABCDEF', 
    'Architecture;DesignPatterns;SOLID;CleanCode');
GO

SELECT * FROM [Category]

SELECT * FROM Course

SELECT * FROM Student