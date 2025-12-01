namespace DevLearningAPI.Models.Dtos.StudantCourse
{
    public class CreateStudantCourseDto
    {
        public Guid CourseId { get; set; }
        public Guid StudantId { get; set; }
        public byte Progress { get; set; } = 0;
        public bool Favorite { get; set; } = false;
   
    }
}
