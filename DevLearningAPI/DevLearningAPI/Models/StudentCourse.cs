namespace DevLearningAPI.Models;

public class StudentCourse
{
    public Guid CourseId { get; set; }
    public Guid StudantId { get; set; }
    public byte Progress { get; set; }
    public bool Favorite { get; set; } = false;
    public DateTime? StartUpdateDate { get; set; }

    public StudentCourse() { } 
    }
