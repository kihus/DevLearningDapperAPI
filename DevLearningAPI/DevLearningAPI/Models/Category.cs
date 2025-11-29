namespace DevLearningAPI.Models;


public class Category(
    string title,
    string url, 
    string summary, 
    int order, 
    string description, 
    bool featured
    )
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; } = title;
    public string Url { get; private set; } = url;
    public string Summary { get; private set; } = summary;
    public int Order { get; private set; } = order;
    public string Description { get; private set; } = description;
    public bool Featured { get; private set; } = featured;
}
