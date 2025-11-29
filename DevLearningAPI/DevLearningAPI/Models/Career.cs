using System.Text.Json.Serialization;

namespace DevLearningAPI.Models;

public class Career(
    string title, 
    string summary, 
    string url, 
    int durationInMinutes, 
    bool featured, 
    string tags
    )
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string Title { get; private set; } = title;

    public string Summary { get; private set; } = summary;

    public string Url { get; private set; } = url;

    public int DurationInMinutes { get; private set; } = durationInMinutes;

    public bool Active { get; private set; } = true;

    public bool Featured { get; private set; } = featured;

    public string Tags { get; private set; } = tags;
}
