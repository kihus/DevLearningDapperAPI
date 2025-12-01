using DevLearningAPI.Models.Dtos.Course;

namespace DevLearningAPI.Models.Dtos.StudantCourse
{
    public class CourseWithRelationDto
    {
        public CourseResponseDto Course { get; init; }
        public byte Progress { get; init; }
        public bool Favorite { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime LastUpdateDate { get; init; }
    }
}
