use DevLearning
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
