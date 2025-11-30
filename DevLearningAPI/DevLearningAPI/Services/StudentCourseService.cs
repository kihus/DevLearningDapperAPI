using DevLearningAPI.Models.Dtos.StudantCourse;
using DevLearningAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DevLearningAPI.Services
{
    public class StudentCourseService
    {
        private readonly StudentCourseRepository _repository;

        public StudentCourseService(StudentCourseRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<StudentCourseResponseDto>> GetAllStudentCoursesAsync()
        {
            return await _repository.GetAllStudentCoursesAsync();
        }

        public async Task CreateStudentCourseAsync(Guid studentId, Guid courseId)
        {
            if (studentId == Guid.Empty || courseId == Guid.Empty)
            {
                throw new ArgumentException("StudentId and CourseId must be valid GUID's.");
            }

            await _repository.CreateStudentCourseAsync(studentId, courseId);
        }

        public async Task<byte?> UpdateCourseProgressAsync(Guid studentId, Guid courseId, int minutesWatched)
        {
            return await _repository.UpdateCourseProgressAsync(studentId, courseId, minutesWatched);
        }


        public async Task<bool> UpdateFavoriteStudentCourse(Guid studentId, Guid courseId)
        {
            return await _repository.UpdateFavoriteStudentCourse(studentId, courseId);
        }

    }
}
