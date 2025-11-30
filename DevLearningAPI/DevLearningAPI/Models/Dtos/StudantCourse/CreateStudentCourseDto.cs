namespace DevLearningAPI.Models.Dtos.StudantCourse
{
    public class CreateStudentCourseDto
    {
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
        public byte Progress { get; set; } = 0;
        public bool Favorite { get; set; } = false;
   
    }
}
