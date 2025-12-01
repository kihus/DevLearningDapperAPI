using DevLearningAPI.Models;
using DevLearningAPI.Models.Dtos.Author;

namespace DevLearningAPI.Repositories.Interfaces;

public interface IAuthorRepository
{
    Task<List<AuthorResponseDto>> GetAllAuthorsAsync();
    Task<AuthorResponseDto> GetAuthorByIdAsync(Guid id);
    Task CreateAuthorAsync(Author author);
    Task UpdateAuthorAsync(Guid id, Author author);
    Task UpdateTypeAuthorAsync(Guid id);
}
