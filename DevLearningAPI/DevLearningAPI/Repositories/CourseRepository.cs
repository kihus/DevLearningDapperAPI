using DevLearningAPI.Database;
using DevLearningAPI.Repositories.Interfaces;

namespace DevLearningAPI.Repositories;

public class CourseRepository : ICourseRepository
{
	private readonly DbConnectionFactory _connection;

	public CourseRepository(DbConnectionFactory connection)
	{
		_connection = connection;
	}
}
