using DevLearningAPI.Models;
using DevLearningAPI.Models.Dtos.Course;
using DevLearningAPI.Repositories.Interfaces;
using DevLearningAPI.Services.Interfaces;

namespace DevLearningAPI.Services;

public class CourseService : ICourseService
{
	private readonly AuthorRepository _repository;

	public CourseService(AuthorRepository repository)
	{
		_repository = repository;
	}
}
