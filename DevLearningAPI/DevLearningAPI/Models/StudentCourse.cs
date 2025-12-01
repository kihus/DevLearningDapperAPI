using System.Text.Json.Serialization;

namespace DevLearningAPI.Models;

public class StudentCourse
{
    public Guid CourseId { get; set; }
    public Guid StudentId { get; set; }
    public byte Progress { get; set; }
    public bool Favorite { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? LastUpdateDate { get; set; }


    public StudentCourse() { }

    public StudentCourse(Guid courseId, Guid studentId)
    {
        CourseId = courseId;
        StudentId = studentId;
        Progress = 0;
        Favorite = false;
        StartDate = DateTime.Now;
        LastUpdateDate = null;
    }
}
