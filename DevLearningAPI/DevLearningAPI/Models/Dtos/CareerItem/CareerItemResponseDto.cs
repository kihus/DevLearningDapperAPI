namespace DevLearningAPI.Models.Dtos.CareerItem
{
    public class CareerItemResponseDto
    {
        public Guid CareerName { get; init; } = Guid.NewGuid();

        public Guid CourseName { get; init; } = Guid.NewGuid();

        public string Title { get; init; } = string.Empty;

        public string Description { get; init; } = string.Empty;

        public int Order { get; init; } = 0;
    }
}
