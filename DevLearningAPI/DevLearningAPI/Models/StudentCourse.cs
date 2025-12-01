using System.Text.Json.Serialization;

namespace DevLearningAPI.Models;

public class StudentCourse
{
    public Guid CourseId { get; private set; }
    public Guid StudentId { get; private set; }
    public byte Progress { get; private set; }
    public bool Favorite { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime LastUpdateDate { get; private set; }


    public StudentCourse() { }

    public StudentCourse(Guid courseId, Guid studentId)
    {
        CourseId = courseId;
        StudentId = studentId;
        Progress = 0;
        Favorite = false;
        StartDate = DateTime.Now;
    }
}
