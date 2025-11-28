# 📘 DevLearning API

Este repositório contém o enunciado e as orientações para desenvolvimento de uma WebAPI em C# (.NET 9+) utilizando Dapper, com base no banco de dados DevLearning fornecido no script SQL.

## 📚 DevLearning – WebAPI com Dapper

API para gerenciamento de cursos, categorias, autores e alunos, com operações completas utilizando Dapper como micro‑ORM.

## 🚀 Objetivo do Exercício

O objetivo é criar uma API REST completa, utilizando:

- ASP.NET Core (.NET 8+)
- Dapper
- SQL Server
- Arquitetura simples porém organizada

A API deve permitir CRUD completo para as principais entidades e endpoints adicionais com relacionamentos entre elas.

## 🗄️ Modelo de Banco de Dados
O banco DevLearning contém estas tabelas:

- Author
- Category
- Course
- Career
- CareerItem
- Student
- StudentCourse

O script completo está disponível no enunciado entregue anteriormente.

## 🔧 Tecnologias Obrigatórias
- .NET 8 ou superior
- ASP.NET Core WebAPI
- Dapper
- SQL Server

## 📌 Requisitos Funcionais da API

### 1. CRUD completo para:
✔️ Author

✔️ Category

✔️ Course

✔️ Student

Cada entidade deve possuir endpoints:

- GET /entity – listar todos
- GET /entity/{id} – obter por ID
- POST /entity – criar
- PUT /entity/{id} – atualizar
- DELETE /entity/{id} – excluir

⚠️ **Use Guid como tipo de ID em todas as entidades.**

### 2. Endpoints Relacionais Obrigatórios

🔹 Listar cursos por categoria

**GET** /categories/{id}/courses

🔹 Listar cursos por autor

**GET** /authors/{id}/courses

🔹 Listar cursos de um aluno

**GET** /students/{id}/courses

🔹 Matricular um aluno em um curso

**POST** /students/{studentId}/courses/{courseId}

Body deve conter:

- progress
- favorite

🔹 Atualizar progresso de um aluno

**PUT** /students/{studentId}/courses/{courseId}/progress

## 🧱 Regras de Implementação
### 1. Uso obrigatório do Dapper

Consultas SQL devem ser feitas com Query, QueryFirstOrDefault e Execute.


### 2. Conexão com SQL Server
Padrão _recomendado_:
```
using var connection = new SqlConnection(configuration.GetConnectionString("Default"));
```
### 3. Tratamento de erros e retornos HTTP
- 200/201 para sucesso
- 204 para updates/deletes
- 400 para erros de entrada
- 404 quando não encontrado
- 500 para exceções inesperadas

### 4. Relacionamentos
O banco não possui DELETE ou UPDATE CASCADE, então exclusões devem ser tratadas cuidadosamente.

## 📂 Estrutura ***SUGERIDA*** do Projeto
DevLearning.Api/ \
│ ├── Controllers/ \
│ ├── AuthorsController.cs \
│ ├── CategoriesController.cs \
│ ├── CoursesController.cs \
│ ├── StudentsController.cs \
│ └── HealthController.cs \
│ ├── Models/ \
│ ├── Author.cs \
│ ├── Category.cs \
│ ├── Career.cs \
│ ├── CareerItem.cs \
│ ├── Course.cs \
│ ├── Student.cs \
│ └── StudentCourse.cs \
│ ├── Dtos/ \
│ ├── Author/ \
│ │ ├── CreateAuthorDto.cs \
│ │ ├── UpdateAuthorDto.cs \
│ │ └── AuthorResponseDto.cs \
│ ├── Category/ \
│ ├── Course/ \
│ └── Student/ \
│ ├── Repositories/ \
│ ├── Interfaces/ \
│ │ ├── IAuthorRepository.cs \
│ │ ├── ICategoryRepository.cs \
│ │ ├── ICourseRepository.cs \
│ │ └── IStudentRepository.cs \
│ ├── AuthorRepository.cs \
│ ├── CategoryRepository.cs \
│ ├── CourseRepository.cs \
│ └── StudentRepository.cs \
│ ├── Services/ \
│ ├── Interfaces/ \
│ │ ├── IAuthorService.cs \
│ │ ├── ICategoryService.cs \
│ │ ├── ICourseService.cs \
│ │ └── IStudentService.cs \
│ ├── AuthorService.cs \
│ ├── CategoryService.cs \
│ ├── CourseService.cs \
│ └── StudentService.cs \
│ ├── Database/ \
│ ├── DbConnectionFactory.cs \
│ └── SqlQueries/ \
│ ├── authors.sql \
│ ├── categories.sql \
│ ├── courses.sql \
│ └── students.sql \
├── appsettings.json \
├── Program.cs \
└── DevLearning.Api.csproj\

## 🧪 Testes e Validação
Sugestão de ferramentas para testar os endpoints:

- **Postman**

🚨 **É importante adicionar no projeto a coleção de testes geradas no Postman para entrega do trabalho!**

# 📅 Prazo de Entrega
**01/12/2025 - 12h**