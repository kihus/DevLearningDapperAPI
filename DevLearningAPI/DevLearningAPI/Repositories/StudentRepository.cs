using DevLearningAPI.Database;
using DevLearningAPI.Repositories.Interfaces;

namespace DevLearningAPI.Repositories;

public class StudentRepository : IStudentRepository
{
	private readonly DbConnectionFactory _connection;

	public StudentRepository(DbConnectionFactory connection)
	{
		_connection = connection;
	}
}
