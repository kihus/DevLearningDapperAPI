using Azure;
using System;

namespace DevLearningAPI.Models.Dtos.Course;

public class CourseResponseDto
{
	public Guid Id { get; init; } = Guid.Empty;
	public string Tag { get; init; } = string.Empty;
	public string Title { get; init; } = string.Empty;
	public string Summary { get; init; } = string.Empty;
	public string Url { get; init; } = string.Empty;
	public int DurationInMinutes { get; init; }
	public int Level { get; init; }
	public DateTime CreateDate { get; init; } 
	public DateTime LastUpdateDate { get; init; }
	public bool Active { get; init; } 
	public bool Free { get; init; } 
	public bool Featured { get; init; } 
	public string AuthorName { get; init; } = string.Empty;
	public string CategoryName { get; init; } = string.Empty;
	public string Tags { get; init; } = string.Empty;
}
