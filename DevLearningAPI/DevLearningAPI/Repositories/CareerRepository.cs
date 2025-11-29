using DevLearningAPI.Database;
using DevLearningAPI.Repositories.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using DevLearningAPI.Models;
using DevLearningAPI.Models.Dtos.Career;
using Microsoft.IdentityModel.Tokens;

namespace DevLearningAPI.Repositories
{
    public class CareerRepository : ICareerRepository
    {

        #region Connection
        private readonly DbConnectionFactory _connection;

        public CareerRepository(DbConnectionFactory connection)
        {
            _connection = connection;
        }

        #endregion

        public async Task CreateCareerAsync(Career career)
        {
            using (var con = _connection.GetConnection())
            {
                var sql = @"INSERT INTO Career(Id,Title,Summary,Url,DurationInMinutes,Active,Featured,Tags)
                                       VALUES (@CareerGuid,@CareerTitle,@CareerSumary,@CareerUrl,@CareerDurationInMinutes,@CareerActive,@CareerFeatured,@CareerTags);";

                await con.ExecuteAsync(sql, new
                {
                    CareerGuid = career.Id,
                    CareerTitle = career.Title,
                    CareerSumary = career.Summary,
                    CareerUrl = career.Url,
                    CareerDurationInMinutes = career.DurationInMinutes,
                    CareerActive = career.Active,
                    CareerFeatured = career.Featured,
                    CareerTags = career.Tags
                }
                                      );
            }

        }

        public async Task<List<CareerResponseDto>> GetAllCareersAsync()
        {
            using (var con = _connection.GetConnection())
            {
                var sql = @"SELECT Id,Title,Summary,Url,DurationInMinutes,Active,Featured,Tags 
                                         FROM Career;";

                return (await con.QueryAsync<CareerResponseDto>(sql)).ToList();
            }

        }
        public async Task<CareerResponseDto> GetCareerByIdAsync(Guid careerId)
        {
            using (var con = _connection.GetConnection())
            {
                var sql = @"SELECT Id,Title,Summary,Url,DurationInMinutes,Active,Featured,Tags 
                                         FROM Career
                                         WHERE Id = @CareerId;";

                return await con.QueryFirstOrDefaultAsync<CareerResponseDto>(sql, new { CareerId = careerId });
            }

        }

        public async Task UpdateCareerAsync(Guid careerId, Career career)
        {
            using (var con = _connection.GetConnection())
            {
                var sql = @"UPDATE Career
                                     SET Title = @CareerTitle,
                                         Summary = @CareerSumary,
                                         Url = @CareerUrl,
                                         DurationInMinutes = @CareerDurationInMinutes,
                                         Active = @CareerActive,
                                         Featured = @CareerFeatured,
                                         Tags = @CareerTags
                                     WHERE Id = @CareerId;";

                await con.ExecuteAsync(sql, new
                {
                    CareerId = careerId,
                    CareerTitle = career.Title,
                    CareerSumary = career.Summary,
                    CareerUrl = career.Url,
                    CareerDurationInMinutes = career.DurationInMinutes,
                    CareerActive = career.Active,
                    CareerFeatured = career.Featured,
                    CareerTags = career.Tags
                });
            }
        }

        public async Task ChangeActiveAsync(Guid careerId)
        {
            using (var con = _connection.GetConnection())
            {
                var sql = @"UPDATE Career
                            SET Active = CASE Active WHEN 0 THEN 1
                                                     WHEN 1 THEN 0
                                                     END
                            WHERE Id = @CareerId;";

                await con.ExecuteAsync(sql, new { CareerId = careerId });
            }

        }

    }
}
