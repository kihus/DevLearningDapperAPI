namespace DevLearningAPI.Models;
public class Course(
	string tag, 
	string title, 
	string summary, 
	string url, 
	int level,
	int durationInMinutes, 
	bool active, 
	bool free, 
	bool featured, 
	Guid authorId, 
	Guid categoryId, 
	string tags
	)
{
	public Guid Id { get; private set; } = Guid.NewGuid();
	public string Tag { get; private set; } = tag;
	public string Title { get; private set; } = title;
	public string Summary { get; private set; } = summary;
	public string Url { get; private set; } = url;
	public int Level { get; private set; } = level;
	public int DurationInMinutes { get; private set; } = durationInMinutes;
	public DateTime CreateDate { get; private set; }
	public DateTime LastUpdateDate { get; private set; }
	public bool Active { get; private set; } = active;
	public bool Free { get; private set; } = free;
	public bool Featured { get; private set; } = featured;
	public Guid AuthorId { get; private set; } = authorId;
	public Guid CategoryId { get; private set; } = categoryId;
	public string Tags { get; private set; } = tags;
}
