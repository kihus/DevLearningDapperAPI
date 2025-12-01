using DevLearningAPI.Models.Dtos.Category;
using DevLearningAPI.Services;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevLearningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService _service;

        public CategoriesController(CategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryResponseDto>>>GetAllCategoriesAsync()
		{
            try
            {
                var categories = await _service.GetAllCategoriesAsync();

                if (categories.Count is 0)
                    return NotFound("Register not found!");

                return categories;
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResponseDto>> GetCategoryByIdAsync(Guid id)
        {
            try
            {
                var category = await _service.GetCategoryByIdAsync(id);

                if (category is null)
                    return NotFound("Register not found!");

                return category;
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategoryAsync(CreateCategoryDto category)
        {
            try
            {
                await _service.CreateCategoryAsync(category);
                return Created();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategoryAsync(Guid id, UpdateCategoryDto categoryRequest)
        {
            try
            {
                var category = await _service.GetCategoryByIdAsync(id);

                if (category is null)
                    return NotFound("Register not found!");

                await _service.UpdateCategoryAsync(id, categoryRequest);
                return NoContent();
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategoryAsync(Guid id)
        {
            try
            {
                var category = await _service.GetCategoryByIdAsync(id);

                if (category is null)
                    return NotFound("Register not found!");

                await _service.DeleteCategoryAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
