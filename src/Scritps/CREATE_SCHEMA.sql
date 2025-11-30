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

