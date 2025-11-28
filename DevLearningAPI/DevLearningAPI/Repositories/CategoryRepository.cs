using DevLearningAPI.Database;
using DevLearningAPI.Repositories.Interfaces;

namespace DevLearningAPI.Repositories;

public class CategoryRepository : ICategoryRepository
{
	private readonly DbConnectionFactory _connection;

	public CategoryRepository(DbConnectionFactory connection)
	{
		_connection = connection;
	}
}
