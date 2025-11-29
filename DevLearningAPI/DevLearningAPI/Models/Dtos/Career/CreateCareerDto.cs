namespace DevLearningAPI.Models.Dtos.Career
{
    public class CreateCareerDto
    {

        public string Title { get; init; } = string.Empty;

        public string Summary { get; init; } = string.Empty;

        public string Url { get; init; } = string.Empty;

        public int DurationInMinutes { get; init; }

        public bool Featured { get; init; }

        public string Tags { get; init; } = string.Empty;
    }
}
