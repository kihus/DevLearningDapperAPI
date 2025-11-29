using DevLearningAPI.Models.Dtos.Student;
using Microsoft.AspNetCore.Mvc;

namespace DevLearningAPI.Services.Interfaces;

public interface IStudentService
{
    public Task<List<StudentResponseDto>> GetAllStudentsAsync();
    public Task CreateStudentAsync(CreateStudentDto studentCreate);
    public Task UpdateEmailStudentAsync(Guid studentId, UpdateStudentEmailDto dtoEmail);
    public Task UpdatePhoneStudentAsync(Guid studentId, UpdateStudentPhoneDto dtoPhone);
    public Task DeleteStudentAsync(Guid studentId);
}
