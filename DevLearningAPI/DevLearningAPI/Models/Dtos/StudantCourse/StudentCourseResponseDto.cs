using DevLearningAPI.Models.Dtos.Course;
using DevLearningAPI.Models.Dtos.Student;

namespace DevLearningAPI.Models.Dtos.StudantCourse
{
    public class StudentCourseResponseDto
    {
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public string Phone { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime CreateDate{ get; set; }
        public List<CourseWithRelationDto> Courses { get; set; } = new List<CourseWithRelationDto>();
    }
}
