using Azure;
using System;

namespace DevLearningAPI.Models.Dtos.Course;

public class CreateCourseDto
{
	public string Tag { get; init; } = string.Empty;
	public string Title { get; init; } = string.Empty;
	public string Summary { get; init; } = string.Empty;
	public string Url { get; init; } = string.Empty;
	public int Level { get; init; }
	public int DurationInMinutes { get; init; } 
	public bool Free { get; init; }
	public bool Featured { get; init; } 
	public Guid AuthorId { get; init; } = Guid.Empty;
	public Guid CategoryId { get; init; } = Guid.Empty;
	public string Tags { get; init; } = string.Empty;
}
