namespace DevLearningAPI.Models.Dtos.Course;

public class AuthorCategoryDto
{
	public Guid AuthorId { get; init; } = Guid.Empty;
	public Guid CategoryId { get; init; } = Guid.Empty;
}
