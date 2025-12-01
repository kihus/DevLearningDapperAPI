using DevLearningAPI.Models.Dtos.Course;
using DevLearningAPI.Models.Dtos.Student;

namespace DevLearningAPI.Models.Dtos.StudantCourse
{
    public class StudentCourseResponseDto
    {
        public Guid StudentId { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string Document { get; init; } = string.Empty;
        public string Phone { get; init; } = string.Empty;
        public DateTime Birthdate { get; init; }
        public DateTime CreateDate { get; init; }
        public List<CourseWithRelationDto> Courses { get; init; } = [];
    }
}
