using DevLearningAPI.Database;
using DevLearningAPI.Repositories;
using DevLearningAPI.Repositories.Interfaces;
using DevLearningAPI.Services;
using DevLearningAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<DbConnectionFactory>();

builder.Services.AddScoped<AuthorRepository>();
builder.Services.AddScoped<AuthorService>();

builder.Services.AddScoped<ICareerRepository,CareerRepository>();
builder.Services.AddScoped<ICareerService,CareerService>();

builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<CategoryService>();

builder.Services.AddScoped<CourseRepository>();
builder.Services.AddScoped<CourseService>();

builder.Services.AddScoped<StudentRepository>();
builder.Services.AddScoped<StudentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
