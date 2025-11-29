namespace DevLearningAPI.Models;

public class CareerItem(Guid careerId, Guid courseId, string title, string description, int order)
{
    public int CareerId { get; set; }
    public int CourseId { get; set; }
    public string Title { get; set; }
    public string MyProperty { get; set; }
    public int Order { get; set; }
}
