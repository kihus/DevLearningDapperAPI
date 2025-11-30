using DevLearningAPI.Models;
using DevLearningAPI.Models.Dtos.Student;
using DevLearningAPI.Repositories;
using DevLearningAPI.Services.Interfaces;

namespace DevLearningAPI.Services;

public class StudentService : IStudentService
{
    private readonly StudentRepository _repository;

    public StudentService(StudentRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<StudentResponseDto>> GetAllStudentsAsync()
    {
        return await _repository.GetAllStudentsAsync();
    }

    public async Task CreateStudentAsync(CreateStudentDto studentCreate)
    {
        var student = new Student(
            studentCreate.Name,
            studentCreate.Email,
            studentCreate.Document,
            studentCreate.Phone,
            studentCreate.BirthDate
         );

        await _repository.CreateStudentAsync(student);
    }

    public async Task UpdateEmailStudentAsync(Guid studentId, UpdateStudentEmailDto dtoEmail)
    {
        await _repository.UpdateEmailStudentAsync(studentId, dtoEmail.Email);
    }

    public async Task UpdatePhoneStudentAsync(Guid studentId, UpdateStudentPhoneDto dtoPhone)
    {
        await _repository.UpdatePhoneStudentAsync(studentId, dtoPhone.Phone);
    }

    public async Task<bool> DeleteStudentAsync(Guid studentId)
    {
        return await _repository.DeleteStudentAsync(studentId);
    }
}
