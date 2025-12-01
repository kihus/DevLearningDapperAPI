namespace DevLearningAPI.Models.Dtos.StudantCourse
{
    public class UpdateFavoritosStudentCourseDto
    {
        public Guid StudentId { get; init; }
        public Guid CourseId { get; init; }
    }
}
