namespace DevLearningAPI.Models.Dtos.Career
{
    public class ItemsResponseDto
    {
        public Guid Id { get; set; }

        public string CourseTitle { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Order { get; set; }
    }
    
}
