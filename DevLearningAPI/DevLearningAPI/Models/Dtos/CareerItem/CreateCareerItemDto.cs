namespace DevLearningAPI.Models.Dtos.CareerItem
{
    public class CreateCareerItemDto
    {
        public Guid CareerId { get; init; } = Guid.NewGuid();

        public Guid CourseId { get; init; } = Guid.NewGuid();

        public string Title { get; init; } = string.Empty;

        public string Description { get; init; } = string.Empty;

        public int Order { get; init; } = 0;
    }
}
