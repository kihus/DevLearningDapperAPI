using DevLearningAPI.Models.Dtos.StudantCourse;

namespace DevLearningAPI.Repositories.Interfaces
{
    public interface IStudentCourseRepository
    {
        public Task<List<StudentCourseResponseDto>> GetAllStudentCoursesAsync();
        public Task CreateStudentCourseAsync(Guid studentId, Guid courseId);
        public Task<int> GetCourseDurationInMinutesAsync(Guid courseId);
        public Task<int> GetProgressStudentCourseAsync(Guid studentId, Guid courseId);
        public Task<byte?> UpdateCourseProgressAsync(Guid studentId, Guid courseId, int minutesWatched);
        public Task<bool> UpdateFavoriteStudentCourse(Guid studentId, Guid courseId);
    }
}
