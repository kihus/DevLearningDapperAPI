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
}
