using DevLearningAPI.Models.Dtos.Category;

namespace DevLearningAPI.Services.Interfaces;

public interface ICategoryService
{
    Task<List<CategoryResponseDto>> GetAllCategoriesAsync();
    Task<CategoryResponseDto> GetCategoryByIdAsync(Guid id);
    Task CreateCategoryAsync(CreateCategoryDto category);
    Task UpdateCategoryAsync(Guid id, UpdateCategoryDto categoryRequest);
    Task DeleteCategoryAsync(Guid id);
}
