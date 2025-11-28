using DevLearningAPI.Repositories;
using DevLearningAPI.Services.Interfaces;

namespace DevLearningAPI.Services;

public class CategoryService : ICategoryService
{
	private readonly AuthorRepository _repository;

	public CategoryService(AuthorRepository repository)
	{
		_repository = repository;
	}
}
