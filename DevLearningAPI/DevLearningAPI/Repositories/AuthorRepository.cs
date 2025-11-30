using DevLearningAPI.Database;
using DevLearningAPI.Repositories.Interfaces;

namespace DevLearningAPI.Repositories;

public class AuthorRepository : IAuthorRepository
{
	private readonly DbConnectionFactory _connection;

	public AuthorRepository(DbConnectionFactory connection)
	{
		_connection = connection;
	}


}
