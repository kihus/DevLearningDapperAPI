using DevLearningAPI.Models;
using DevLearningAPI.Models.Dtos.Author;
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

	public async Task<List<AuthorResponseDto>> GetAllAuthorsAsync()
	{
		return await _repository.GetAllAuthorsAsync();
	}

	public async Task<AuthorResponseDto> GetAuthorByIdAsync(Guid id)
	{
		return await _repository.GetAuthorByIdAsync(id);
	}

	public async Task CreateAuthorAsync(CreateAuthorDto author)
	{
		var newAuthor = new Author(
			author.Name,
			author.Title,
			author.Image,
			author.Bio,
			author.Url,
			author.Email
			);

		await _repository.CreateAuthorAsync(newAuthor);
	}

	public async Task UpdateAuthorAsync(Guid id, UpdateAuthorDto authorRequest)
	{
		var author = await _repository.GetAuthorByIdAsync(id);

		var newAuthor = new Author(
			string.IsNullOrEmpty(authorRequest.Name)
								? author.Name
								: authorRequest.Name,
			string.IsNullOrEmpty(authorRequest.Title)
								? author.Title
								: authorRequest.Title,
			string.IsNullOrEmpty(authorRequest.Image)
								? author.Image
								: authorRequest.Image,
			string.IsNullOrEmpty(authorRequest.Bio)
								? author.Bio
								: authorRequest.Bio,
			string.IsNullOrEmpty(authorRequest.Url)
								? author.Url
								: authorRequest.Url,
			string.IsNullOrEmpty(authorRequest.Email)
								? author.Email
								: authorRequest.Email
			);

		await _repository.UpdateAuthorAsync(id, newAuthor);
	}

	public async Task UpdateTypeAuthorAsync(Guid id)
	{
		await _repository.UpdateTypeAuthorAsync(id);
	}
}
