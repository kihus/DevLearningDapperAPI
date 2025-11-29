SELECT * FROM Category

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

