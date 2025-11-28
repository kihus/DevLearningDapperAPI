using DevLearningAPI.Repositories;
using DevLearningAPI.Services.Interfaces;

namespace DevLearningAPI.Services;

public class StudentService : IStudentService
{
	private readonly AuthorRepository _repository;

	public StudentService(AuthorRepository repository)
	{
		_repository = repository;
	}
}
