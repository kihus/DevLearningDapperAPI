using DevLearningAPI.Models.Dtos.Course;

namespace DevLearningAPI.Services.Interfaces;

public interface ICourseService
{
	public Task<List<CourseResponseDto>> GetAllCoursesAsync();
	public Task<CourseResponseDto?> GetCourseByIdAsync(Guid id);
	public Task CreateCourseAsync(CreateCourseDto courseDto);
	public Task UpdateCourseAsync(Guid id, UpdateCourseDto courseDto);
	public Task<bool?> ActiveCourseAsync(Guid id);
    public Task<bool?> DeleteCourseAsync(Guid id);
}
