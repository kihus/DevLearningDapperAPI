using Dapper;
using DevLearningAPI.Models;
using DevLearningAPI.Models.Dtos.Career;

namespace DevLearningAPI.Repositories;

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

                var sql = @"SELECT CA.Id,CA.Title,CA.Summary,CA.Url,CA.DurationInMinutes,CA.Active,CA.Featured,CA.Tags,
                                   CO.Id,CO.Title AS CourseTitle,
                                   CI.Title,CI.Description, CI.[Order]
                            FROM Career CA
                            LEFT JOIN CareerItem CI ON CI.CareerId = CA.Id
                            LEFT JOIN Course CO ON CO.Id = CI.CourseId
                            ORDER BY CI.[Order];";

                var careerDictionary = new Dictionary<Guid, CareerResponseDto>();

                await con.QueryAsync<CareerResponseDto, ItemsResponseDto, CareerResponseDto>(sql,
                                                                                                (career, item) => 
                                                                                                {
                                                                                                
                                                                                                    if (!careerDictionary.TryGetValue(career.Id, out var existingCareer))
                                                                                                
                                                                                                    {
                                                                                                
                                                                                                        careerDictionary.Add(career.Id, career);
                                                                                                
                                                                                                        existingCareer = career;
                                                                                                
                                                                                                    }
                                                                                                
                                                                                                
                                                                                                
                                                                                                    if (item != null)
                                                                                                
                                                                                                    {
                                                                                                
                                                                                                        existingCareer.Items.Add(item);
                                                                                                
                                                                                                    }
                                                                                                    return existingCareer; 
                                                                                                },
                                                                                                splitOn: "Id"
                                                                                            );

                return careerDictionary.Values.ToList();
            }

        }
        public async Task<CareerResponseDto> GetCareerByIdAsync(Guid careerId)
        {
            using (var con = _connection.GetConnection())
            {
                var sql = @"SELECT CA.Id,CA.Title,CA.Summary,CA.Url,CA.DurationInMinutes,CA.Active,CA.Featured,CA.Tags,
                                   CO.Id,CO.Title AS CourseTitle,
                                   CI.Title,CI.Description,CI.[Order]
                            FROM Career CA
                            LEFT JOIN CareerItem CI ON CI.CareerId = CA.Id
                            LEFT JOIN Course CO ON CO.Id = CI.CourseId
                            WHERE CA.Id = @CareerId
                            ORDER BY CI.[Order];";

                var careerDictionary = new Dictionary<Guid, CareerResponseDto>();

                await con.QueryAsync<CareerResponseDto, ItemsResponseDto, CareerResponseDto>(sql,
                                                                                                (career, item) =>
                                                                                                {

                                                                                                    if (!careerDictionary.TryGetValue(career.Id, out var existingCareer))

                                                                                                    {

                                                                                                        careerDictionary.Add(career.Id, career);

                                                                                                        existingCareer = career;

                                                                                                    }



                                                                                                    if (item != null)

                                                                                                    {

                                                                                                        existingCareer.Items.Add(item);

                                                                                                    }
                                                                                                    return existingCareer;
                                                                                                },
                                                                                                param: new { CareerId = careerId },
                                                                                                splitOn: "Id"
                                                                                            );

                return careerDictionary.Values.FirstOrDefault();
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
