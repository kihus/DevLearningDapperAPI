
﻿using Dapper;
using DevLearningAPI.Database;
using DevLearningAPI.Models;
using DevLearningAPI.Models.Dtos.Course;
using DevLearningAPI.Models.Dtos.StudantCourse;
using DevLearningAPI.Models.Dtos.Student;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DevLearningAPI.Repositories
{
    public class StudentCourseRepository
    {
        private readonly DbConnectionFactory _connection;

        public StudentCourseRepository(DbConnectionFactory connection)
        {
            _connection = connection;
        }

        public async Task<List<StudentCourseResponseDto>> GetAllStudentCoursesAsync()
        {
            var sql = @"SELECT s.Id AS StudentId, s.Name, s.Email, s.Document, s.Phone, s.Birthdate, s.CreateDate AS StudentCreateDate,
                        sc.Progress, 
                        sc.Favorite AS SCFavorite, 
                        sc.StartDate, 
                        sc.LastUpdateDate AS RelationLastUpdateDate,
                        sc.StudentId,
                        sc.CourseId, 
                        c.Id AS Id, c.Tag, c.Title, c.Summary, c.Url, c.DurationInMinutes, c.Level, c.CreateDate AS CourseCreateDate,
                        c.LastUpdateDate  AS CourseLastUpdateDate, c.Active, c.Free, c.Featured, c.Tags, 
                        a.Name AS AuthorName, ca.Title AS CategoryName
                    FROM Student s
                    INNER JOIN StudentCourse sc
                    ON sc.StudentId = s.Id
                    JOIN Course c
                    ON c.Id = sc.CourseId
                    JOIN Author a
                    ON c.AuthorId = a.Id
                    JOIN Category ca
                    ON c.CategoryId = ca.Id";

            using (var con = _connection.GetConnection())
            {
                var studentDictionary = new Dictionary<Guid, StudentCourseResponseDto>();

                await con.QueryAsync<StudentCourseResponseDto, StudentCourse, CourseResponseDto, StudentCourseResponseDto>(
                    sql,
                    (student, studentCourse, course) =>
                    {
                        if (!studentDictionary.TryGetValue(student.StudentId, out var studentEntry))  //studentEntry recebe o valor do dicionario se a chave ja existir
                        {
                            studentEntry = student;
                            studentDictionary.Add(studentEntry.StudentId, studentEntry);
                        }

                        var courseWithRelation = new CourseWithRelationDto
                        {
                            Course = course,
                            Progress = GetProgressStudentCourseAsync(student.StudentId, course.Id).Result,
                            SCFavorite = studentCourse.Favorite,
                            StartDate = studentCourse.StartDate,
                            CourseLastUpdateDate = studentCourse.LastUpdateDate
                        };

                        studentEntry.Courses.Add(courseWithRelation);

                        return studentEntry;
                    },
                    splitOn: "StudentId,Progress,Id"
                );
                return studentDictionary.Values.ToList();
            }
        }

        public async Task CreateStudentCourseAsync(Guid studentId, Guid courseId)
        {
            var sql = @"INSERT INTO StudentCourse(StudentId, CourseId, Progress, Favorite, StartDate) 
                    VALUES (@StudentId, @CourseId, @Progress, @Favorite, @StartDate)";


            using (var con = _connection.GetConnection())
            {
                var studentCourse = new StudentCourse(courseId, studentId);

                await con.ExecuteAsync(sql, new
                {
                    StudentId = studentCourse.StudentId,
                    CourseId = studentCourse.CourseId,
                    studentCourse.Progress,
                    studentCourse.Favorite,
                    StartDate = DateTime.Now
                });
            }
        }

        public async Task<int?> GetCourseDurationInMinutesAsync(Guid courseId)
        {
            var sql = @"SELECT DurationInMinutes
                              FROM Course
                              WHERE Id = @CourseId";

            using (var con = _connection.GetConnection())
            {
                return await con.QueryFirstOrDefaultAsync<int?>(sql, new { CourseId = courseId });
            }
        }

        public async Task<byte> GetProgressStudentCourseAsync(Guid studentId, Guid courseId)
        {
            var sql = @"SELECT Progress
                              FROM studentCourse
                              WHERE StudentId = @StudentId AND CourseId = @CourseId";

            using (var con = _connection.GetConnection())
            {
                return await con.QueryFirstOrDefaultAsync<byte>(sql, new { StudentId = studentId, CourseId = courseId });
            }
        }

        public async Task<byte?> UpdateCourseProgressAsync(Guid studentId, Guid courseId, int minutesWatched)
        {
            var duration = await GetCourseDurationInMinutesAsync(courseId);
            if (duration == null)
                return null;

            var existsRelationShip = await GetProgressStudentCourseAsync(studentId, courseId);
            if (existsRelationShip == null)
                return null;

            double percent = (minutesWatched / (double)duration) * 100;

            if (percent > 100)
                percent = 100;

            byte progress = (byte)percent;

            var sql = @"UPDATE StudentCourse 
                        SET Progress = @Progress, 
                            LastUpdateDate = GETDATE()
                        WHERE StudentId = @StudentId 
                        AND CourseId = @CourseId";

            using (var con = _connection.GetConnection())
            {
                await con.ExecuteAsync(sql, new { Progress = progress, StudentId = studentId, CourseId = courseId });
            }
            return progress;
        }


        public async Task<bool> UpdateFavoriteStudentCourse(Guid studentId, Guid courseId)
        {
            using (var con = _connection.GetConnection())
            {
                var sqlSelect = @"SELECT Favorite
                        FROM StudentCourse
                        WHERE StudentId = @StudentId AND CourseId = @CourseId";


                //bool newValue = !favorite;

                var sqlUpdate = @"UPDATE StudentCourse
                              SET Favorite = CASE Favorite WHEN 0 THEN 1
                                             WHEN 1 THEN 0
                                             END,
                              LastUpdateDate = GETDATE()
                              WHERE StudentId = @StudentId 
                              AND CourseId = @CourseId";

                /*@"UPDATE Career
                    SET Active = CASE Active WHEN 0 THEN 1
                                             WHEN 1 THEN 0
                                             END
                    WHERE Id = @CareerId;";*/

                await con.ExecuteAsync(sqlUpdate,
                    new { StudentId = studentId, CourseId = courseId });

                var favorite = await con.ExecuteScalarAsync<bool>(sqlSelect, new { StudentId = studentId, CourseId = courseId });

                return favorite;
            }
        }

    }

}
