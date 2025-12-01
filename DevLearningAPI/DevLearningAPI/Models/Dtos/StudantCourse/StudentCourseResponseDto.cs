using DevLearningAPI.Models.Dtos.Course;
using DevLearningAPI.Models.Dtos.Student;

namespace DevLearningAPI.Models.Dtos.StudantCourse
{
    public class StudentCourseResponseDto
    {
        public Guid SCStudentId { get; set; }
        public Guid SCCourseId { get; set; }
        public byte SCProgress { get; set; }
        public bool SCFavorite { get; set; }
        public DateTime SCStartDate { get; set; }
        public DateTime? SCLastUpdateDate { get; set; }
        public List<CourseWithRelationDto> Courses { get; set; } = new List<CourseWithRelationDto>();
    }
}
