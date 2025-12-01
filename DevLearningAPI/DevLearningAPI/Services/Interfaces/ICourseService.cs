using DevLearningAPI.Models.Dtos.Course;

namespace DevLearningAPI.Services.Interfaces;

public interface ICourseService
{
	public Task<List<CourseResponseDto>> GetAllCoursesAsync();
	public Task<CourseResponseDto?> GetCourseByIdAsync(Guid id);
	public Task CreateCourseAsync(CreateCourseDto courseDto);
	public Task UpdateCourseAsync(Guid id, UpdateCourseDto courseDto);
	public Task DeleteCourseAsync(Guid id);
	public Task ActiveCourseAsync(Guid id);
	public Task<bool> SelectCourseByStudentAsync(Guid courseId);
    public Task<List<CourseResponseDto>> GetAllCoursesOrderedAsync();
}
