using DevLearningAPI.Models.Dtos.Course;

namespace DevLearningAPI.Models.Dtos.StudantCourse
{
    public class CourseWithRelationDto
    {
        public CourseResponseDto Course { get; init; }
        public byte Progress { get; init; }
        public bool SCFavorite { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime CourseLastUpdateDate { get; init; }
    }
}
