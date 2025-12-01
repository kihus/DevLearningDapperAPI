namespace DevLearningAPI.Models;

public class CareerItem(
    Guid careerId, 
    Guid courseId, 
    string title, 
    string description, 
    int order
    )
{
    public Guid CareerId { get; private set; } = careerId;

    public Guid CourseId { get; private set; } = courseId;

    public string Title { get; private set; } = title;

    public string Description { get; private set; } = description;

    public int Order { get; private set; } = order;
}
