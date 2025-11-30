using DevLearningAPI.Models;
using DevLearningAPI.Models.Dtos.Category;

namespace DevLearningAPI.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<List<CategoryResponseDto>> GetAllCategoriesAsync();
    Task<CategoryResponseDto> GetCategoryByIdAsync(Guid id);
    Task CreateCategoryAsync(Category category);
    Task UpdateCategoryAsync(Guid id, Category category);
    Task DeleteCategoryAsync(Guid id);
}
