using DevLearningAPI.Models;
using DevLearningAPI.Models.Dtos.Course;

namespace DevLearningAPI.Repositories.Interfaces;

public interface ICourseRepository
{
	public Task<List<CourseResponseDto>> GetAllCoursesAsync();
	public Task<CourseResponseDto?> GetCourseByIdAsync(Guid id);
	public Task CreateCourseAsync(Course course);
	public Task UpdateCourseAsync(Guid id, Course course);
	public Task DeleteCourseAsync(Guid id);
}
