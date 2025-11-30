using Dapper;
using DevLearningAPI.Database;
using DevLearningAPI.Models;
using DevLearningAPI.Models.Dtos.Course;
using DevLearningAPI.Repositories.Interfaces;

namespace DevLearningAPI.Repositories;

public class CourseRepository : ICourseRepository
{
	private readonly DbConnectionFactory _connection;

	public CourseRepository(DbConnectionFactory connection)
	{
		_connection = connection;
	}

	public async Task<List<CourseResponseDto>> GetAllCoursesAsync()
	{
		var sql = @"SELECT co.Id, co.Tag, co.Title, co.Summary, co.Url, co.DurationInMinutes, co.Level, 
                           co.CreateDate, co.LastUpdateDate, co.Active, co.Free, co.Featured, co.Tags,      
						   a.[Name] AS AuthorName, ca.[Title] AS CategoryName 
					FROM Course co
					JOIN Author a
					ON co.AuthorId = a.Id
					JOIN Category ca
					ON co.CategoryId = ca.Id";

		using (var con = _connection.GetConnection())
		{
			return (await con.QueryAsync<CourseResponseDto>(sql)).ToList();
		}
	}

	public async Task<CourseResponseDto?> GetCourseByIdAsync(Guid id)
	{
		var sql = @"SELECT co.Id, co.Tag, co.Title, co.Summary, co.Url, co.DurationInMinutes, co.Level,  
                           co.CreateDate, co.LastUpdateDate, co.Active, co.Free, co.Featured, co.Tags,    
						   a.[Name] AS AuthorName, ca.[Title] AS CategoryName 
					FROM Course co
					JOIN Author a
					ON co.AuthorId = a.Id
					JOIN Category ca
					ON co.CategoryId = ca.Id
					WHERE co.Id = @Id";

		using (var con = _connection.GetConnection())
		{
			return await con.QueryFirstOrDefaultAsync<CourseResponseDto>(sql, new { id });
		}
	}

	public async Task<AuthorCategoryDto> GetAuthorCategoryId(Guid id)
	{
		var sql = @"SELECT AuthorId, CategoryId FROM Course WHERE Id = @Id";

		using (var con = _connection.GetConnection())
		{
			return await con.QueryFirstOrDefaultAsync<AuthorCategoryDto>(sql, new { id });
		}
	}

	public async Task CreateCourseAsync(Course course)
	{
		var sql = @"INSERT INTO Course ([Id], 
										[Tag], 
										[Title], 
										[Summary], 
										[Url], 
										[Level], 
										[DurationInMinutes], 
										[CreateDate], 
										[LastUpdateDate], 
										[Active], 
										[Free],
										[Featured],
										[AuthorId], 
										[CategoryId], 
										[Tags])
				    VALUES (@Id,
							@Tag,
							@Title,
							@Summary,
							@Url,
							@Level,
							@DurationInMinutes,
							GETDATE(),
							GETDATE(),
							@Active,
							@Free,
							@Featured,
							@AuthorId,
							@CategoryId,
							@Tags)";

		using (var con = _connection.GetConnection())
		{
			await con.ExecuteAsync(sql, new
			{
				course.Id,
				course.Tag,
				course.Title,
				course.Summary,
				course.Url,
				course.Level,
				course.DurationInMinutes,
				course.Active,
				course.Free,
				course.Featured,
				course.AuthorId,
				course.CategoryId,
				course.Tags
			});
		}
	}

    public async Task<bool> CourseExistsAsync(Guid id)
    {
        var sql = @"SELECT COUNT(1) FROM Course WHERE Id = @Id";

        using (var con = _connection.GetConnection())
        {
            var count = await con.ExecuteScalarAsync<int>(sql, new { Id = id });
            return count > 0;
        }
    }

    public async Task UpdateCourseAsync(Guid id, Course course)
	{
		var sql = @"UPDATE Course SET [Tag] = @Tag, 
									  [Title] = @Title, 
									  [Summary] = @Summary, 
								      [Url] = @Url, 
								      [Level] = @Level, 
									  [DurationInMinutes] = @DurationInMinutes, 
									  [LastUpdateDate] = GETDATE(), 
									  [Active] = @Active, 
									  [Free] = @Free, 
									  [AuthorId] = @AuthorId, 
									  [CategoryId] = @CategoryId, 
									  [Tags] = @Tags 
					WHERE Id = @Id";

		using (var con = _connection.GetConnection())
		{
			await con.ExecuteAsync(sql, new
			{
				course.Tag,
				course.Title,
				course.Summary,
				course.Url,
				course.Level,
				course.DurationInMinutes,
				course.Active,
				course.Free,
				course.AuthorId,
				course.CategoryId,
				course.Tags,
				id
			});
		}
	}

	public async Task<bool?> GetCourseActiveAsync(Guid id)
	{
		var sql = @"SELECT Active FROM Course WHERE Id = @Id";
		using (var con = _connection.GetConnection())
		{
			return await con.QueryFirstOrDefaultAsync<bool?>(sql, new { Id = id });
		}
    }

    public async Task<bool?> ActiveCourseAsync(Guid id)
    {

        var active = await GetCourseActiveAsync(id);

        if (active == null)
            return null;

        if (active == true)
            return true;

        var sqlUpdateActive = @"UPDATE Course
                    SET Active = @Active, LastUpdateDate = GETDATE() 
                    WHERE Id = @Id";

        bool newValue = true;

        using (var con = _connection.GetConnection())
        {
            await con.ExecuteAsync(sqlUpdateActive, new { Active = newValue, Id = id });
        }
        return newValue;
    }




    public async Task<bool?> DeleteCourseAsync(Guid id)
	{
		
			var active = await GetCourseActiveAsync(id);

			if (active == null)
				return null;

			bool newValue = false;

			var sqlUpdateActive = @"UPDATE Course
                    SET Active = @Active, LastUpdateDate = GETDATE() 
                    WHERE Id = @Id";

		    var sqlDeleteRelation = @"DELETE FROM StudentCourse
					WHERE CourseId = @Id";

		using (var con = _connection.GetConnection())
		{
			await con.ExecuteAsync(sqlUpdateActive, new { Active = newValue, Id = id });
			await con.ExecuteAsync(sqlDeleteRelation, new { Id = id });
        }
		return newValue;
	}
}
