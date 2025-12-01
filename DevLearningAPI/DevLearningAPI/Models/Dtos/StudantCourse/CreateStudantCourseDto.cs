namespace DevLearningAPI.Models.Dtos.StudantCourse
{
    public class CreateStudantCourseDto
    {
        public Guid CourseId { get; init; }
        public Guid StudantId { get; init; }
        public byte Progress { get; init; } = 0;
        public bool Favorite { get; init; } = false;
   
    }
}
