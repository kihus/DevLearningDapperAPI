using DevLearningAPI.Models;
using DevLearningAPI.Models.Dtos.Course;
using DevLearningAPI.Repositories.Interfaces;
using DevLearningAPI.Services.Interfaces;

namespace DevLearningAPI.Services;

public class CourseService : ICourseService
{
	private readonly ICourseRepository _repository;

	public CourseService(ICourseRepository repository)
	{
		_repository = repository;
	}

	public async Task<List<CourseResponseDto>> GetAllCoursesAsync()
	{
		var courses = await _repository.GetAllCoursesAsync();
        return courses.OrderBy(x => x.Title).ToList();
	}

	public async Task<CourseResponseDto?> GetCourseByIdAsync(Guid id)
	{
		return await _repository.GetCourseByIdAsync(id);
	}

	public async Task CreateCourseAsync(CreateCourseDto courseDto)
	{
		var course = new Course(
			courseDto.Tag,
			courseDto.Title,
			courseDto.Summary,
			courseDto.Url,
			courseDto.Level,
			courseDto.DurationInMinutes,
			true,
			courseDto.Free,
			courseDto.Featured,
			courseDto.AuthorId,
			courseDto.CategoryId,
			courseDto.Tags
			);

		await _repository.CreateCourseAsync(course);
	}

	public async Task UpdateCourseAsync(Guid id, UpdateCourseDto courseDto)
	{
		var courseResponse = await _repository.GetCourseByIdAsync(id);
		var authorCategory = await _repository.GetAuthorCategoryId(id);

		var course = new Course(
			string.IsNullOrEmpty(courseDto.Tag)
								? courseResponse.Tag
								: courseDto.Tag,
			string.IsNullOrEmpty(courseDto.Title)
								? courseResponse.Title
								: courseDto.Title,
			string.IsNullOrEmpty(courseDto.Summary)
								? courseResponse.Summary
								: courseDto.Summary,
			string.IsNullOrEmpty(courseDto.Url)
								? courseResponse.Url
								: courseDto.Url,
			courseDto.Level is 0
					  ? courseResponse.Level
					  : courseDto.Level,
			courseDto.DurationInMinutes is 0
					  ? courseResponse.DurationInMinutes
					  : courseDto.DurationInMinutes,
			courseDto.Active,
			courseDto.Free,
			courseDto.Featured,
			courseDto.AuthorId == Guid.Empty
					  ? authorCategory.AuthorId
					  : courseDto.AuthorId,
			courseDto.CategoryId == Guid.Empty
					  ? authorCategory.CategoryId
					  : courseDto.CategoryId,
			string.IsNullOrEmpty(courseDto.Tags)
								? courseResponse.Tags
								: courseDto.Tags
			);

		await _repository.UpdateCourseAsync(id, course);
	}

	public async Task DeleteCourseAsync(Guid id)
	{
		await _repository.DeleteCourseAsync(id);
	}







	public async Task<List<CourseResponseDto>> GetAllCoursesOrderedAsync()
	{
		return await _repository.GetAllCoursesOrderedAsync();
	}

}
