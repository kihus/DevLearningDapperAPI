namespace DevLearningAPI.Models.Dtos.CareerItem
{
    public class UpdateCareerItemDto
    {
        public Guid CareerId { get; init; }

        public Guid CourseId { get; init; }
        public string Title { get; init; } = string.Empty;

        public string Description { get; init; } = string.Empty;

        public int Order { get; init; } = 0;
    }
}
