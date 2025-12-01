using Dapper;
using DevLearningAPI.Database;
using DevLearningAPI.Models;
using DevLearningAPI.Models.Dtos.CareerItem;
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

        public async Task<CareerItemResponseDto> GetCareerItemByCareerIdAsync(Guid careerId)
        {
            using (var con = _connecton.GetConnection())
            {
                var sql = @"SELECT CareerId,CourseId,Title,Description,[Order]
                            FROM CareerItem
                            WHERE CareerId = @CareerId";

                return await con.QueryFirstOrDefaultAsync<CareerItemResponseDto>(sql, new { CareerId = careerId });
            }
            
        }

        public async Task<CareerItemResponseDto> GetCareerItemByCourseIdAsync(Guid courseId)
        {
            using (var con = _connecton.GetConnection())
            {
                var sql = @"SELECT CareerId,CourseId,Title,Description,[Order]
                            FROM CareerItem
                            WHERE CourseId = @CourseId";

                return await con.QueryFirstOrDefaultAsync<CareerItemResponseDto>(sql, new { CourseId = courseId });
            }
        }

        public async Task<CareerItemResponseDto> GetCareerItemByCareerCourseIdAsync(Guid careerId, Guid courseId)
        {
            using (var con = _connecton.GetConnection())
            {
                var sql = @"SELECT CareerId,CourseId,Title,Description,[Order]
                            FROM CareerItem
                            WHERE CareerId = @CareerId
                            AND CourseId = @CourseId";

                return await con.QueryFirstOrDefaultAsync<CareerItemResponseDto>(sql, new { CareerId = careerId,CourseId = courseId });
            }
        }

        public async Task UpdateCareerItemAsync(CareerItem careerItem)
        {
            using (var con = _connecton.GetConnection())
            {
                var sql = @"UPDATE CareerItem 
                            SET Title = @Title, 
                                Description = @Description, 
                                [Order] = @Order
                            WHERE CareerId = @CareerId
                            AND CourseId = @CourseId";

                await con.ExecuteAsync(sql, new
                {
                    CareerId = careerItem.CareerId,
                    CourseId = careerItem.CourseId,
                    Title = careerItem.Title,
                    Description = careerItem.Description,
                    Order = careerItem.Order
                }
                                       );
            }
        }

        public async Task DeleteAllCareerItemByCareerIdAsync(Guid careerId)
        {
            using(var con = _connecton.GetConnection())
            {
                var sql = @"DELETE FROM CareerItem
                            WHERE CareerId = @CareerId";

                await con.ExecuteAsync(sql, new { CareerId = careerId });
            }
        }

        public async Task DeleteAllCareerItemByCourseIdAsync(Guid courseId)
        {
            using (var con = _connecton.GetConnection())
            {
                var sql = @"DELETE FROM CareerItem
                            WHERE CourseId = @CourseId";

                await con.ExecuteAsync(sql, new { CourseId = courseId });
            }
        }

        public async Task DeleteCareerItemByCareerCourseIdAsync(Guid careerId, Guid courseId)
        {
            using (var con = _connecton.GetConnection())
            {
                var sql = @"DELETE FROM CareerItem
                            WHERE CareerId = @CareerId
                            AND CourseId = @CourseId";

                await con.ExecuteAsync(sql, new { CareerId = careerId,CourseId = courseId });
            }
        }
    }
}
