USE [DevLearning]
GO

-- ==========================================================
-- 1. AUTORES (5 Registros - GUIDs Válidos)
-- ==========================================================
INSERT INTO [Author] ([Id], [Name], [Title], [Image], [Bio], [Url], [Email], [Type]) VALUES
('8A1C5D9F-2B3E-4A5C-6D7E-8F9A0B1C2D3E', 'Gustavo', 'Microsoft MVP', 'https://balta.io/img/gustavo.jpg', 'Especialista em .NET', 'gustavo', 'gustavo@balta.io', 1),
('B2C3D4E5-F6A7-8B9C-0D1E-2F3A4B5C6D7E', 'Virgínia', 'Tech Lead', 'https://balta.io/img/virginia.jpg', 'Especialista em Cloud', 'virginia', 'virginia@balta.io', 1),
('C1D2E3F4-A5B6-7C8D-9E0F-1A2B3C4D5E6F', 'Uncle Bob', 'Clean Coder', 'https://balta.io/img/bob.jpg', 'Autor de Clean Code', 'uncle-bob', 'bob@cleancoder.com', 0),
('D3E4F5A6-B7C8-9D0E-1F2A-3B4C5D6E7F8A', 'Martin Fowler', 'Chief Scientist', 'https://balta.io/img/martin.jpg', 'Padrões de Arquitetura', 'martin-fowler', 'martin@fowler.com', 0),
('E5F6A7B8-C9D0-1E2F-3A4B-5C6D7E8F9A0B', 'Elemar Jr', 'MVP', 'https://balta.io/img/elemar.jpg', 'Functional Programming', 'elemar-jr', 'elemar@exemplo.com', 1);

-- ==========================================================
-- 2. CATEGORIAS (5 Registros - GUIDs Válidos)
-- ==========================================================
INSERT INTO [Category] ([Id], [Title], [Url], [Summary], [Order], [Description], [Featured]) VALUES
('11223344-5566-7788-99AA-BBCCDDEEFF00', 'Backend', 'backend', 'C#, Java, Node', 1, 'Server side', 1),
('09876543-2109-8765-4321-FEDCBA987654', 'Frontend', 'frontend', 'HTML, CSS, JS', 2, 'Client side', 1),
('AA11BB22-CC33-DD44-EE55-1234567890AB', 'Database', 'database', 'SQL e NoSQL', 3, 'Dados', 0),
('99887766-5544-3322-1100-AABBCCDDEEFF', 'DevOps', 'devops', 'CI/CD, Docker', 4, 'Infra', 0),
('1234ABCD-5678-EF90-1234-567890ABCDEF', 'Mobile', 'mobile', 'Flutter, Maui', 5, 'Apps', 0);

-- ==========================================================
-- 3. ESTUDANTES (5 Registros)
-- Corrigido: Substituído prefixo "S" (inválido) por "A"
-- ==========================================================
INSERT INTO [Student] ([Id], [Name], [Email], [Document], [Phone], [Birthdate]) VALUES
('A1111111-1111-1111-1111-111111111111', 'Alice', 'alice@student.com', '12345678900', '11999999999', '1995-01-01'),
('A2222222-2222-2222-2222-222222222222', 'Bob', 'bob@student.com', '12345678901', '11888888888', '1998-05-20'),
('A3333333-3333-3333-3333-333333333333', 'Charlie', 'charlie@student.com', '12345678902', '11777777777', '2000-12-10'),
('A4444444-4444-4444-4444-444444444444', 'Diana', 'diana@student.com', '12345678903', '11666666666', '1990-07-15'),
('A5555555-5555-5555-5555-555555555555', 'Eduardo', 'edu@student.com', '12345678904', '11555555555', '1985-03-30');

-- ==========================================================
-- 4. CARREIRAS (5 Registros)
-- Corrigido: Substituído prefixo "CAR" (inválido) por "B00"
-- ==========================================================
INSERT INTO [Career] ([Id], [Title], [Summary], [Url], [DurationInMinutes], [Active], [Featured], [Tags]) VALUES
('B0011111-1111-1111-1111-111111111111', 'Especialista Backend .NET', 'Domine C#', 'backend-dotnet', 1000, 1, 1, 'C#;.NET'),
('B0022222-2222-2222-2222-222222222222', 'Fullstack Developer', 'Do front ao back', 'fullstack', 2000, 1, 1, 'JS;C#;SQL'),
('B0033333-3333-3333-3333-333333333333', 'DBA Master', 'Domine SQL Server', 'dba-master', 800, 1, 0, 'SQL;Tuning'),
('B0044444-4444-4444-4444-444444444444', 'DevOps Ninja', 'Azure e Docker', 'devops-ninja', 600, 1, 0, 'Docker;K8s'),
('B0055555-5555-5555-5555-555555555555', 'Mobile Expert', 'Apps nativos', 'mobile-expert', 1200, 1, 1, 'Flutter;Maui');

-- ==========================================================
-- 5. CURSOS (5 Registros)
-- Corrigido: Substituído prefixo "CRS" (inválido) por "C00"
-- ==========================================================
INSERT INTO [Course] ([Id], [Tag], [Title], [Summary], [Url], [Level], [DurationInMinutes], [CreateDate], [LastUpdateDate], [Active], [Free], [Featured], [AuthorId], [CategoryId], [Tags]) VALUES
-- Curso 1: C# (Autor: Gustavo, Categoria: Backend)
('C0011111-1111-1111-1111-111111111111', 'CSHARP', 'Fundamentos do C#', 'Básico de C#', 'csharp-fundamentos', 1, 120, GETDATE(), GETDATE(), 1, 1, 0, 
 '8A1C5D9F-2B3E-4A5C-6D7E-8F9A0B1C2D3E', '11223344-5566-7788-99AA-BBCCDDEEFF00', 'C#;Logic'),

-- Curso 2: Angular (Autor: Virginia, Categoria: Frontend)
('C0022222-2222-2222-2222-222222222222', 'ANGULAR', 'Angular Avançado', 'SPA Modernas', 'angular-avancado', 2, 300, GETDATE(), GETDATE(), 1, 0, 1, 
 'B2C3D4E5-F6A7-8B9C-0D1E-2F3A4B5C6D7E', '09876543-2109-8765-4321-FEDCBA987654', 'JS;Angular'),

-- Curso 3: SQL Tuning (Autor: Uncle Bob (exemplo), Categoria: Database)
('C0033333-3333-3333-3333-333333333333', 'SQLOPT', 'Otimização SQL', 'Indices e Plans', 'sql-opt', 3, 200, GETDATE(), GETDATE(), 1, 0, 0, 
 'C1D2E3F4-A5B6-7C8D-9E0F-1A2B3C4D5E6F', 'AA11BB22-CC33-DD44-EE55-1234567890AB', 'SQL;Perf'),

-- Curso 4: Docker (Autor: Elemar, Categoria: DevOps)
('C0044444-4444-4444-4444-444444444444', 'DOCKER', 'Docker para Devs', 'Containers', 'docker-devs', 2, 180, GETDATE(), GETDATE(), 1, 1, 1, 
 'E5F6A7B8-C9D0-1E2F-3A4B-5C6D7E8F9A0B', '99887766-5544-3322-1100-AABBCCDDEEFF', 'Docker;Linux'),

-- Curso 5: MAUI (Autor: Gustavo, Categoria: Mobile)
('C0055555-5555-5555-5555-555555555555', 'MAUI', 'MAUI Multiplataforma', 'Apps C#', 'maui-apps', 2, 400, GETDATE(), GETDATE(), 1, 0, 1, 
 '8A1C5D9F-2B3E-4A5C-6D7E-8F9A0B1C2D3E', '1234ABCD-5678-EF90-1234-567890ABCDEF', 'C#;Mobile');

-- ==========================================================
-- 6. ITENS DE CARREIRA (5 Registros)
-- Corrigido: Atualizado para os novos IDs (B00... e C00...)
-- ==========================================================
INSERT INTO [CareerItem] ([CareerId], [CourseId], [Title], [Description], [Order]) VALUES
-- Carreira Backend (B001) -> Curso C# (C001)
('B0011111-1111-1111-1111-111111111111', 'C0011111-1111-1111-1111-111111111111', 'Começando com C#', 'O básico', 1),
-- Carreira Fullstack (B002) -> Curso Angular (C002)
('B0022222-2222-2222-2222-222222222222', 'C0022222-2222-2222-2222-222222222222', 'Frontend Moderno', 'Interfaces ricas', 1),
-- Carreira DBA (B003) -> Curso SQL (C003)
('B0033333-3333-3333-3333-333333333333', 'C0033333-3333-3333-3333-333333333333', 'Performance', 'Ajuste fino', 1),
-- Carreira DevOps (B004) -> Curso Docker (C004)
('B0044444-4444-4444-4444-444444444444', 'C0044444-4444-4444-4444-444444444444', 'Containers', 'Ambiente', 1),
-- Carreira Mobile (B005) -> Curso MAUI (C005)
('B0055555-5555-5555-5555-555555555555', 'C0055555-5555-5555-5555-555555555555', 'Apps Híbridos', 'Codando', 1);

-- ==========================================================
-- 7. CURSOS DO ALUNO (5 Registros)
-- Corrigido: Atualizado para os novos IDs (C00... e A111...)
-- ==========================================================
INSERT INTO [StudentCourse] ([CourseId], [StudentId], [Progress], [Favorite], [StartDate], [LastUpdateDate]) VALUES
-- Alice (A111) fazendo C# (C001)
('C0011111-1111-1111-1111-111111111111', 'A1111111-1111-1111-1111-111111111111', 10, 1, GETDATE(), GETDATE()),
-- Bob (A222) fazendo Angular (C002)
('C0022222-2222-2222-2222-222222222222', 'A2222222-2222-2222-2222-222222222222', 50, 0, GETDATE(), GETDATE()),
-- Charlie (A333) fazendo SQL (C003)
('C0033333-3333-3333-3333-333333333333', 'A3333333-3333-3333-3333-333333333333', 100, 1, GETDATE(), GETDATE()),
-- Diana (A444) fazendo Docker (C004)
('C0044444-4444-4444-4444-444444444444', 'A4444444-4444-4444-4444-444444444444', 0, 0, GETDATE(), GETDATE()),
-- Edu (A555) fazendo MAUI (C005)
('C0055555-5555-5555-5555-555555555555', 'A5555555-5555-5555-5555-555555555555', 75, 1, GETDATE(), GETDATE());
GO

