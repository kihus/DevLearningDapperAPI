namespace DevLearningAPI.Models.Dtos.Category;

public class CategoryResponseDto
{
    public Guid Id { get; init; } = Guid.Empty;
    public string Title { get; init; } = string.Empty;
    public string Url { get; init; }= string.Empty;
    public string Summary { get; init; } = string.Empty;
    public int Order { get; init; } = 0;
    public string Description { get; init; } = string.Empty;
    public bool Featured { get; init; } = false;
}
