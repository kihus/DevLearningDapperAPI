namespace DevLearningAPI.Models;

public class CareerItem(Guid careerId, Guid courseId, string title, string description, int order)
{

    public Guid CareerId { get; set; } = careerId;

    public Guid CourseId { get; set; } = courseId;

    public string Title { get; set; } = title;

    public string Description { get; set; } = description;

    public int Order { get; set; } = order;
}
