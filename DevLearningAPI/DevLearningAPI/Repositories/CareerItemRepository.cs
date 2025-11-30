using Dapper;
using DevLearningAPI.Database;
using DevLearningAPI.Models;
using DevLearningAPI.Repositories.Interfaces;

namespace DevLearningAPI.Repositories;

public class CareerItemRepository : ICareerItemRepository
{
    #region ConnectionDependencyInjection
    private readonly DbConnectionFactory _connecton;

    public CareerItemRepository(DbConnectionFactory connection)
    {
        _connecton = connection;
    }
    #endregion

    public async Task CreateCareerItemAsync(CareerItem careerItem)
    {
        using(var con = _connecton.GetConnection())
        {
            var sql = @"INSERT INTO CareerItem (CareerId, CourseId, Title, Description, [Order])
                                         VALUES(@CareerId, @CourseId, @Title, @Description,@Order) ";

            await con.ExecuteAsync(sql, new {CareerId = careerItem.CareerId,
                                             CourseId = careerItem.CourseId,
                                             Title = careerItem.Title,
                                             Description = careerItem.Description,
                                             Order = careerItem.Order}
                                             );
        }
    }
}
