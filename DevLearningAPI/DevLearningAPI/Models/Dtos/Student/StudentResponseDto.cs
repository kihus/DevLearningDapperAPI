namespace DevLearningAPI.Models.Dtos.Student;

public class StudentResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Document { get; set; }
    public string? Phone { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTime CreateDate { get; set; }
}
