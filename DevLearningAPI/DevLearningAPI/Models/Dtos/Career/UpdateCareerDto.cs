namespace DevLearningAPI.Models.Dtos.Career
{
    public class UpdateCareerDto
    {
        public string Title { get; init; } = string.Empty;

        public string Summary { get; init; } = string.Empty;

        public string Url { get; init; } = string.Empty;

        public int DurationInMinutes { get; init; } = 0;

        public bool Active { get; init; } = false;

        public bool Featured { get; init; } = false;

        public string Tags { get; init; } = string.Empty;
    }
}
