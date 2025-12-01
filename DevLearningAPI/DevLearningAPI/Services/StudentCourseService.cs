using DevLearningAPI.Models;
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

        public async Task CreateStudentCourseAsync(CreateStudantCourseDto studentCourse, Guid studentId, Guid courseId)
        {
            var newStudentCourse =  new StudentCourse
            (
                studentCourse.StudantId,
                studentCourse.CourseId
            );
            if (studentId == Guid.Empty || courseId == Guid.Empty)
            {
                throw new ArgumentException("StudentId and CourseId must be valid GUID's.");
            }

            await _repository.CreateStudentCourseAsync(studentId, courseId);
        }

        public async Task UpdateCourseProgressAsync(Guid studentId, Guid courseId, int minutesWatched)
        {
            var duration = await _repository.GetCourseDurationInMinutesAsync(courseId);
            if (duration == null)
                return;


            double percent = (minutesWatched / (double)duration) * 100;

            if (percent > 100)
                percent = 100;

            byte progress = (byte)percent;
            await _repository.UpdateCourseProgressAsync(studentId, courseId, minutesWatched, progress);
        }


        public async Task<bool> UpdateFavoriteStudentCourse(Guid studentId, Guid courseId)
        {
            return await _repository.UpdateFavoriteStudentCourse(studentId, courseId);
        }

        internal async Task<bool> GetRelationStudentCourseAsync(Guid studentId, Guid courseId)
        {

            var existsRelationShip = await _repository.GetProgressStudentCourseAsync(studentId, courseId);
            if (existsRelationShip == null)
                return false;

            return true;
        }
    }
}
