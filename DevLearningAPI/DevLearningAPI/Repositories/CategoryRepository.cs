using Dapper;
using DevLearningAPI.Database;
using DevLearningAPI.Models;
using DevLearningAPI.Models.Dtos.Category;
using DevLearningAPI.Repositories.Interfaces;

namespace DevLearningAPI.Repositories;

public class CategoryRepository : ICategoryRepository
{
	private readonly DbConnectionFactory _connection;

	public CategoryRepository(DbConnectionFactory connection)
	{
		_connection = connection;
	}

	public async Task<List<CategoryResponseDto>> GetAllCategoriesAsync()
	{
		var sql = "SELECT Id, Title, Url, Summary, [Order], Description, Featured FROM Category";

		using(var con = _connection.GetConnection())
		{
			return (await con.QueryAsync<CategoryResponseDto>(sql)).ToList();
		}
	}

	public async Task<CategoryResponseDto> GetCategoryByIdAsync(Guid id)
	{
		var sql = "SELECT Id, Title, Url, Summary, [Order], Description, Featured FROM Category WHERE Id = @Id";

        using (var con = _connection.GetConnection())
		{
            return await con.QueryFirstOrDefaultAsync<CategoryResponseDto>(sql, new { Id = id });
		}
    }

	public async Task CreateCategoryAsync(Category category)
	{
		var sql = @"INSERT INTO Category (Id, Title, [Url], Summary, [Order], [Description], Featured) 
					VALUES (@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";

        using (var con = _connection.GetConnection())
		{
            await con.ExecuteAsync(sql, 
			new { Id = category.Id, Title = category.Title, Url = category.Url, Summary = category.Summary, Order = category.Order,
			Description = category.Description, Featured = category.Featured});
		}
    }

	public async Task UpdateCategoryAsync(Guid id, Category category)
	{
		var sql = @"UPDATE Category
					SET Title = @Title, Url = @Url, Summary = @Summary, [Order] = @Order, Description = @Description, Featured = @Featured 
					WHERE Id = @Id";

		using (var con = _connection.GetConnection())
		{
			await con.ExecuteAsync(sql, new { category.Title, category.Url, category.Summary, category.Order, 
											  category.Description, category.Featured, id});
		}
	}

	public async Task DeleteCategoryAsync(Guid id)
	{
		var sql = "DELETE FROM Category WHERE Id = @Id";

		using(var con = _connection.GetConnection())
		{
			await con.ExecuteAsync(sql, new { id });
		}
	}
}
