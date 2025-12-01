using DevLearningAPI.Models;
using DevLearningAPI.Models.Dtos.Category;
using DevLearningAPI.Repositories;
using DevLearningAPI.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace DevLearningAPI.Services;

public class CategoryService : ICategoryService
{
	private readonly CategoryRepository _repository;

	public CategoryService(CategoryRepository repository)
	{
		_repository = repository;
	}

	public async Task<List<CategoryResponseDto>> GetAllCategoriesAsync()
	{
		return await _repository.GetAllCategoriesAsync();
	}

	public async Task<CategoryResponseDto> GetCategoryByIdAsync(Guid id)
	{
		return await _repository.GetCategoryByIdAsync(id);
	}

	public async Task CreateCategoryAsync(CreateCategoryDto category)
	{
		var newCategory = new Category(category.Title, 
									   category.Url, 
									   category.Summary, 
									   category.Order, 
									   category.Description,
									   category.Featured);

		await _repository.CreateCategoryAsync(newCategory);
	}

	public async Task UpdateCategoryAsync(Guid id, UpdateCategoryDto categoryRequest)
	{
		var category = await _repository.GetCategoryByIdAsync(id);

		var newCategory = new Category(

			string.IsNullOrEmpty(categoryRequest.Title) 
							   ? category.Title 
							   : categoryRequest.Title,
            string.IsNullOrEmpty(categoryRequest.Url) 
							   ? category.Url 
							   : categoryRequest.Url,
            string.IsNullOrEmpty(categoryRequest.Summary) 
							   ? category.Summary 
							   : categoryRequest.Summary,
								 categoryRequest.Order is 0 
							   ? category.Order 
							   : categoryRequest.Order,
			string.IsNullOrEmpty(categoryRequest.Description) 
							   ? category.Description 
							   : categoryRequest.Description,

								 categoryRequest.Featured
									  );

		await _repository.UpdateCategoryAsync(id, newCategory);
	}

	public async Task DeleteCategoryAsync(Guid id)
	{
		await _repository.DeleteCategoryAsync(id);
	}
}
