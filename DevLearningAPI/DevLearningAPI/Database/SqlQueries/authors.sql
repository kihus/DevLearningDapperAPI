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