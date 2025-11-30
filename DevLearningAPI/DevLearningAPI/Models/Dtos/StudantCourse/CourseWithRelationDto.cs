using DevLearningAPI.Models.Dtos.Course;

namespace DevLearningAPI.Models.Dtos.StudantCourse
{
    public class CourseWithRelationDto
    {
        public CourseResponseDto Course { get; set; }
        public byte Progress { get; set; }
        public bool Favorite { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}
