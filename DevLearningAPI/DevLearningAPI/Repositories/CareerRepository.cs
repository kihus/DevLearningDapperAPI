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

        #region SqlQueries
        private static readonly string InsertCareer = @"INSERT INTO Career(Id,Title,Summary,Url,DurationInMinutes,Active,Featured,Tags)
                                                                   VALUES (@CareerGuid,@CareerTitle,@CareerSumary,@CareerUrl,@CareerDurationInMinutes,@CareerActive,@CareerFeatured,@CareerTags);";

        private static readonly string SelectAllCareers = @"SELECT Id,Title,Summary,Url,DurationInMinutes,Active,Featured,Tags 
                                                            FROM Career;";

        private static readonly string SelectCareerById = @"SELECT Id,Title,Summary,Url,DurationInMinutes,Active,Featured,Tags 
                                                            FROM Career
                                                            WHERE Id = @CareerId;";

        private static readonly string UpdateCareer = @"UPDATE Career
                                                        SET Title = @CareerTitle,
                                                            Summary = @CareerSumary,
                                                            Url = @CareerUrl,
                                                            DurationInMinutes = @CareerDurationInMinutes,
                                                            Active = @CareerActive,
                                                            Featured = @CareerFeatured,
                                                            Tags = @CareerTags
                                                        WHERE Id = @CareerId;";

        private static readonly string UpdateActive = @"UPDATE Career
                                                        Set Active = CASE Active WHEN 0 THEN 1
                                                                                 WHEN 1 THEN 0
                                                                                 END
                                                        WHERE Id = @CareerId;";
        #endregion

        public async Task CreateCareerAsync(Career career)
        {
            using (var con = _connection.GetConnection())
            {
                await con.ExecuteAsync(InsertCareer, new
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
                return (await con.QueryAsync<CareerResponseDto>(SelectAllCareers)).ToList();
            }

        }
        public async Task<CareerResponseDto> GetCareerByIdAsync(Guid careerId)
        {
            using (var con = _connection.GetConnection())
            {
                return await con.QueryFirstOrDefaultAsync<CareerResponseDto>(SelectCareerById, new { CareerId = careerId });
            }

        }

        public async Task UpdateCareerAsync(Guid careerId, Career career)
        {
            using (var con = _connection.GetConnection())
            {
                await con.ExecuteAsync(UpdateCareer, new
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
                await con.ExecuteAsync(UpdateActive, new { CareerId = careerId });
            }

        }

    }
}
