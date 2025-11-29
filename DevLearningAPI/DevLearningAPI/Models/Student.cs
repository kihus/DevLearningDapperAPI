namespace DevLearningAPI.Models;

public class Student(
    string name,
    string email,
    string document,
    string phone,
    DateTime? birthDate
    )
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = name;
    public string Email { get; set; } = email;
    public string Document { get; set; } = document;
    public string? Phone { get; set; } = phone;
    public DateTime? BirthDate { get; set; } = birthDate;
    public DateTime CreateDate { get; set; } = DateTime.Now;


}
