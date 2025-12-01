using DevLearningAPI.Models.Dtos.StudantCourse;

namespace DevLearningAPI.Services.Interfaces
{
    public interface IStudentCourseService
    {
        public Task<List<StudentCourseResponseDto>> GetAllStudentCoursesAsync();
        public Task CreateStudentCourseAsync(Guid studentId, Guid courseId);
        public Task<byte?> UpdateCourseProgressAsync(Guid studentId, Guid courseId, int minutesWatched);
        public Task<bool> UpdateFavoriteStudentCourse(Guid studentId, Guid courseId);
    }
}
