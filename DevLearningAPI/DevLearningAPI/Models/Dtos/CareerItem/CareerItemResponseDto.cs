namespace DevLearningAPI.Models.Dtos.CareerItem
{
    public class CareerItemResponseDto
    {
        public string CareerName { get; init; } = string.Empty;

        public string CourseName { get; init; } = string.Empty;

        public string Title { get; init; } = string.Empty;

        public string Description { get; init; } = string.Empty;

        public int Order { get; init; } = 0;
    }
}
