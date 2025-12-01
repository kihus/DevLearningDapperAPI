/*
INSERT INTO [Author] ([Id], [Name], [Title], [Image], [Bio], [Url], [Email], [Type])
VALUES
    (NEWID(), 'Maria Silva', 'Desenvolvedora Sênior', 'http://img.com/maria.jpg', 'Especialista em C# e .NET Core.', 'http://linkedin.com/maria', 'maria@dev.com', 1),
    (NEWID(), 'João Santos', 'Arquiteto Cloud', 'http://img.com/joao.jpg', 'Foco em AWS e infraestrutura como código.', 'http://linkedin.com/joao', 'joao@dev.com', 2),
    (NEWID(), 'Ana Costa', 'Designer UX/UI', 'http://img.com/ana.jpg', 'Experiência em Figma e metodologias ágeis.', 'http://linkedin.com/ana', 'ana@dev.com', 1),
    (NEWID(), 'Pedro Lima', 'Especialista em Dados', 'http://img.com/pedro.jpg', 'Análise de dados com Python e R.', 'http://linkedin.com/pedro', 'pedro@dev.com', 2),
    (NEWID(), 'Helena Alves', 'Engenheira de Software', 'http://img.com/helena.jpg', 'Desenvolvimento mobile (iOS/Android).', 'http://linkedin.com/helena', 'helena@dev.com', 1);


INSERT INTO [Category] ([Id], [Title], [Url], [Summary], [Order], [Description], [Featured])
VALUES
    (NEWID(), 'Desenvolvimento Web', 'http://url.com/web', 'Cursos para front-end e back-end moderno.', 1, 'Detalhes sobre tecnologias web como React, Node.js.', 1),
    (NEWID(), 'Cloud Computing', 'http://url.com/cloud', 'Tudo sobre AWS, Azure e Google Cloud.', 2, 'Descrição de serviços de computação em nuvem e DevOps.', 1),
    (NEWID(), 'Design', 'http://url.com/design', 'Aprenda a criar interfaces e experiências incríveis.', 3, 'Princípios de UX, UI e ferramentas de prototipagem.', 0),
    (NEWID(), 'Data Science', 'http://url.com/data', 'Análise, visualização e Machine Learning.', 4, 'Cursos de estatística, Python e algoritmos de ML.', 1),
    (NEWID(), 'Mobile', 'http://url.com/mobile', 'Desenvolvimento para plataformas móveis nativas e híbridas.', 5, 'Foco em Swift, Kotlin e React Native.', 0);

INSERT INTO [Student] ([Id], [Name], [Email], [Document], [Phone], [Birthdate])
VALUES
    (NEWID(), 'Alice Pereira', 'alice@aluno.com', '12345678900', '11987654321', '1995-03-10'),
    (NEWID(), 'Bruno Ramos', 'bruno@aluno.com', '00987654321', '21991234567', '2000-11-25'),
    (NEWID(), 'Carla Oliveira', 'carla@aluno.com', '11223344556', '31988776655', '1992-05-15'),
    (NEWID(), 'David Fernandes', 'david@aluno.com', '66554433221', '41977665544', '1999-01-01'),
    (NEWID(), 'Eva Mendes', 'eva@aluno.com', '77889900112', '51966554433', '1997-08-20');

INSERT INTO [Career] ([Id], [Title], [Summary], [Url], [DurationInMinutes], [Active], [Featured], [Tags])
VALUES
    (NEWID(), 'Desenvolvedor Back-end C#', 'Trilha para dominar o ecossistema .NET Core.', 'http://carreiras.com/backend-csharp', 3000, 1, 1, '.NET, C#, API, SQL'),
    (NEWID(), 'Especialista em Design de Produto', 'Foco na criação de produtos digitais de sucesso.', 'http://carreiras.com/design-produto', 2200, 1, 0, 'UX, UI, Figma, Prototipagem'),
    (NEWID(), 'Jornada Python para ML', 'Do zero aos modelos de Machine Learning.', 'http://carreiras.com/python-ml', 4500, 1, 1, 'Python, Pandas, Scikit-learn, Estatística');

INSERT INTO [Course] ([Id], [Tag], [Title], [Summary], [Url], [Level], [DurationInMinutes], [CreateDate], [LastUpdateDate], [Active], [Free], [Featured], [AuthorId], [CategoryId], [Tags])
VALUES
    (NEWID(), 'CSHARP', 'C# Fundamentos Essenciais', 'A base para começar a desenvolver com C#.', 'http://curso.com/csharp-base', 1, 480, GETDATE(), GETDATE(), 1, 0, 1,'97E21ED5-489E-44D0-B094-CA71C958EE1C', 'FACB0E2D-8924-4253-928C-E4537C342E84', 'C#, .NET, Fundamentos'), 
    (NEWID(), 'AWS', 'Introdução ao S3 e EC2', 'Primeiros passos nos serviços de Cloud da AWS.', 'http://curso.com/aws-intro', 1, 300, GETDATE(), GETDATE(), 1, 1, 1,'C2CD4E5E-82CD-47CB-9E97-675576868489', '17A3F798-AAF1-489B-A992-8FBCDBE7A115', 'AWS, Cloud, S3, EC2'), 
    (NEWID(), 'FIGMA', 'Protótipos de Alta Fidelidade', 'Aprenda a criar protótipos avançados no Figma.', 'http://curso.com/figma-pro', 2, 600, GETDATE(), GETDATE(), 1, 0, 0,'94BEEA82-9365-49E2-BB1D-6604CC364370', '3C780802-CB4B-4D92-8EEA-889801738CB9', 'Figma, UX, UI, Design'), 
    (NEWID(), 'PYTHON', 'Estatística com Python', 'Utilizando Pandas e NumPy para análise estatística.', 'http://curso.com/python-estatistica', 2, 720, GETDATE(), GETDATE(), 1, 0, 1,'CAA17A45-282D-4BA5-BAF1-3E791096C0AA', 'ED5E340A-C52C-4BA1-AA04-7A88BCB525A1', 'Python, Data Science, Pandas'), 
    (NEWID(), 'KOTLIN', 'Introdução ao Kotlin', 'Primeiros passos na linguagem oficial do Android.', 'http://curso.com/kotlin-intro', 1, 420, GETDATE(), GETDATE(), 1, 1, 0,'C4600FCF-0694-438F-9BF3-230D3DD89F41', '8380E414-BDB8-4C78-BED8-2F55B79D3586', 'Kotlin, Android, Mobile'); 

INSERT INTO [CareerItem] ([CareerId], [CourseId], [Title], [Description], [Order])
VALUES
    ('A1B2C3D4-E5F6-7890-ABCD-EF0123456789', 'C1058DEC-86EE-4968-AABE-EDAFFDAD373B', 'Módulo 1: Base C#', 'Início da jornada Back-end.', 1), 
    ('8B8D708A-2F64-4207-A56E-AD27035AA9C8', '1314EF91-8BA2-4791-890C-BFE11BB875AF', 'Módulo 2: Hospedagem', 'Hospedando a API na Cloud.', 2), 
    ('4385011A-637D-45D8-91F9-853F7734D9B3', '5B1EEB8D-AE9E-4C86-A186-A3A8D508AA7D', 'Módulo 1: Visão de Produto', 'Primeiro passo na criação de protótipos.', 1), 
    ('AD6371EF-7F7D-4B51-9282-24365FA9D063', '3B06CC60-A96A-47EA-B3B4-6E78DDFD54D8', 'Módulo 1: Preparação', 'Introdução à análise de dados.', 1),
    ('E8EF6DB1-1835-4856-B673-1649864A0D66', 'B397ADE5-B2DE-4AFE-8C9D-235BA46F5843', 'Módulo 1: Linguagem', 'Entendendo a sintaxe Kotlin.', 1);

INSERT INTO [StudentCourse] ([CourseId], [StudentId], [Progress], [Favorite], [StartDate], [LastUpdateDate])
VALUES
    ('C1058DEC-86EE-4968-AABE-EDAFFDAD373B', 'A905752A-A731-481E-AA1A-E97B099E231F', 50, 1, '2025-10-01', GETDATE()),
    ('1314EF91-8BA2-4791-890C-BFE11BB875AF', 'D2F8D715-845D-4683-9DC1-955E1353F109', 100, 0, '2025-09-15', '2025-09-28'),
    ('5B1EEB8D-AE9E-4C86-A186-A3A8D508AA7D', 'CB322F9A-E406-4567-8A83-425A06A3FDBD', 25, 1, '2025-11-20', GETDATE()),
    ('3B06CC60-A96A-47EA-B3B4-6E78DDFD54D8', '5A41927D-E029-4C40-8650-259C7A348707', 0, 0, '2025-11-28', GETDATE()),
    ('B397ADE5-B2DE-4AFE-8C9D-235BA46F5843', 'A31C4E92-6A44-4A08-9EFE-15D6F824ED7A', 75, 1, '2025-10-10', '2025-11-05');

*/

SELECT * 
FROM CareerItem ci
RIGHT JOIN Career ca ON ca.Id = ci.CareerId
LEFT JOIN Course co ON co.Id = ci.CourseId
ORDER BY ci.[Order] ASC

SELECT * FROM Career;

SELECT * FROM Author;

SELECT * FROM Category;

SELECT * FROM Course;

select * from Student;


