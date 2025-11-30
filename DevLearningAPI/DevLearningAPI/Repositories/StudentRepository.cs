using Dapper;
using DevLearningAPI.Database;
using DevLearningAPI.Models;
using DevLearningAPI.Models.Dtos.Student;
using DevLearningAPI.Repositories.Interfaces;

namespace DevLearningAPI.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly DbConnectionFactory _connection;

    public StudentRepository(DbConnectionFactory connection)
    {
        _connection = connection;
    }

    public async Task<List<StudentResponseDto>> GetAllStudentsAsync()
    {
        var sql = @"SELECT Id, Name, Email, Document, Phone, Birthdate, CreateDate
                    FROM Student";

        using (var con = _connection.GetConnection())
        {
            return (await con.QueryAsync<StudentResponseDto>(sql)).ToList();
        }
    }

    public async Task CreateStudentAsync(Student student)
    {
        var sql = @"INSERT INTO Student (Id, Name, Email, Document, Phone, Birthdate, CreateDate) 
                    VALUES (@Id, @Name, @Email, @Document, @Phone, @BirthDate, @CreateDate)";


        using (var con = _connection.GetConnection())
        {
            await con.ExecuteAsync(sql, new
            {
                student.Id,
                student.Name,
                student.Email,
                student.Document,
                student.Phone,
                student.BirthDate,
                student.CreateDate
            });
        }
    }

    public async Task UpdateEmailStudentAsync(Guid studentId, string email)
    {
        var sql = @"UPDATE Student 
                    SET Email = @Email
                    WHERE Id = @Id";

        using (var con = _connection.GetConnection())
        {
            await con.ExecuteAsync(sql, new
            {
                Id = studentId,
                Email = email
            });
        }
    }

    public async Task UpdatePhoneStudentAsync(Guid studentId, string phone)
    {
        var sql = @"UPDATE Student 
                    SET Phone = @Phone
                    WHERE Id = @Id";

        using (var con = _connection.GetConnection())
        {
            await con.ExecuteAsync(sql, new
            {
                Id = studentId,
                Phone = phone
            });
        }
    }
    public async Task<bool> DeleteStudentAsync(Guid studentId)
    {
        using (var con = _connection.GetConnection())
        {
            var sqlExists = @"SELECT COUNT(1) FROM Student WHERE Id = @Id";
            var exists = await con.ExecuteScalarAsync<int>(sqlExists, new { Id = studentId });

            if (exists == 0)
                return false;

            var sqlDeleteRelation = @"Delete FROM StudentCourse 
					WHERE StudentId = @Id";
            await con.ExecuteAsync(sqlDeleteRelation, new { Id = studentId });

            var sqlDeleteStudent = @"Delete FROM Student 
                    WHERE Id = @Id";
            await con.ExecuteAsync(sqlDeleteStudent, new { Id = studentId });

            return true;
        }
    }
}
