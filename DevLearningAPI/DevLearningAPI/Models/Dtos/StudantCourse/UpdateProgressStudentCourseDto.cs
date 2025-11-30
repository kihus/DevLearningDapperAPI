namespace DevLearningAPI.Models.Dtos.StudantCourse
{
    public class UpdateProgressStudentCourseDto
    {
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public int MinutesWatched { get; set; }
    }
}
