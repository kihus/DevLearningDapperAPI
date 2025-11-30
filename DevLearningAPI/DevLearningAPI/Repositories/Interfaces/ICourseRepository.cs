using DevLearningAPI.Models;
using DevLearningAPI.Models.Dtos.Course;

namespace DevLearningAPI.Repositories.Interfaces;

public interface ICourseRepository
{
	public Task<List<CourseResponseDto>> GetAllCoursesAsync();
	public Task<CourseResponseDto?> GetCourseByIdAsync(Guid id);
	public Task CreateCourseAsync(Course course);
	public Task<bool> CourseExistsAsync(Guid id);
    public Task<bool?> GetCourseActiveAsync(Guid id);
	public Task<bool?> ActiveCourseAsync(Guid id);
    public Task UpdateCourseAsync(Guid id, Course course);
	public Task<bool?> DeleteCourseAsync(Guid id);
}
