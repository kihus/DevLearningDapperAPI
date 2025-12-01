using Dapper;
using DevLearningAPI.Database;
using DevLearningAPI.Models;
using DevLearningAPI.Models.Dtos.Author;
using DevLearningAPI.Repositories.Interfaces;

namespace DevLearningAPI.Repositories;

public class AuthorRepository : IAuthorRepository
{
	private readonly DbConnectionFactory _connection;

	public AuthorRepository(DbConnectionFactory connection)
	{
		_connection = connection;
	}

	public async Task<List<AuthorResponseDto>> GetAllActiveAuthorsAsync()
	{
		var sql = "SELECT [Id], [Name], [Title], [Image], [Bio], [Url], [Email], [Type] FROM Author WHERE [Type] = 1";

		using (var con = _connection.GetConnection())
		{
			return (await con.QueryAsync<AuthorResponseDto>(sql)).ToList();
		}
	}

    public async Task<List<AuthorResponseDto>> GetAllAuthorsAsync()
    {
        var sql = "SELECT [Id], [Name], [Title], [Image], [Bio], [Url], [Email], [Type] FROM Author";

        using (var con = _connection.GetConnection())
        {
            return (await con.QueryAsync<AuthorResponseDto>(sql)).ToList();
        }
    }

    public async Task<AuthorResponseDto> GetAuthorByIdAsync(Guid id)
	{
		var sql = "SELECT [Id], [Name], [Title], [Image], [Bio], [Url], [Email], [Type] FROM Author WHERE Id = @Id";

		using (var con = _connection.GetConnection())
		{
			return await con.QueryFirstOrDefaultAsync<AuthorResponseDto>(sql, new{Id = id});
		}
    }

	public async Task CreateAuthorAsync(Author author)
	{
		var sql = @"INSERT INTO Author ([Id], [Name], [Title], [Image], [Bio], [Url], [Email], [Type]) 
					Values (@Id, @Name, @Title, @Image, @Bio, @Url, @Email, @Type)";

		using (var con = _connection.GetConnection())
		{
			await con.ExecuteAsync(sql,
				new {Id = author.Id, Name = author.Name, Title = author.Title, Image = author.Image, Bio = author.Bio, 
				Url = author.Url, Email = author.Email, Type = author.Type});
		}
	}

	public async Task UpdateAuthorAsync(Guid id, Author author)
	{
		var sql = @"UPDATE Author 
					SET [Name] = @Name, [Title] = @Title, [Image] = @Image, [Bio] = @Bio, [Url] = @Url, [Email] = @Email 
					WHERE Id = @Id";

		using (var con = _connection.GetConnection())
		{
			await con.ExecuteAsync(sql, new { author.Name, author.Title, author.Image, author.Bio, author.Url, author.Email, id });
		}
	}

	public async Task UpdateTypeAuthorAsync(Guid id)
	{
		var sql = @"UPDATE Author 
					SET [Type] = CASE [Type] WHEN 0 THEN 1
										   WHEN 1 THEN 0
										   END
					WHERE Id = @Id";

		using(var con = _connection.GetConnection())
		{
			await con.ExecuteAsync(sql, new { Id = id });
		}
	}

	public async Task<ContadorAuthorDto?> SelectAuthorByCourseAsync(Guid authorId)
	{
		var sql = @"SELECT COUNT(Id) AS Quantidade FROM Course WHERE AuthorId = @AuthorId";

		using (var con = _connection.GetConnection())
		{
			return await con.QueryFirstOrDefaultAsync<ContadorAuthorDto>(sql, new { authorId });	
		}
	}
}
