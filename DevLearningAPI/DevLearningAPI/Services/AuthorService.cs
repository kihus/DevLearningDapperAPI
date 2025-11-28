using DevLearningAPI.Repositories;
using DevLearningAPI.Services.Interfaces;

namespace DevLearningAPI.Services;

public class AuthorService : IAuthorService
{
	private readonly AuthorRepository _repository;

	public AuthorService(AuthorRepository repository)
	{
		_repository = repository;
	}
}
