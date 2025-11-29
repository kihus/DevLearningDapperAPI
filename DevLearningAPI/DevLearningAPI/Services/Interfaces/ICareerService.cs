using DevLearningAPI.Models.Dtos.Career;
using Microsoft.AspNetCore.Mvc;

namespace DevLearningAPI.Services.Interfaces
{
    public interface ICareerService
    {
        Task CreateCareerAsync(CreateCareerDto career);

        Task<List<CareerResponseDto>> GetAllCareersAsync();

        Task<CareerResponseDto> GetCareerByIdAsync(Guid careerId);

        Task UpdateCareerAsync(Guid careerId, UpdateCareerDto careerRequest);

        Task ChangeActiveAsync(Guid careerId);
    }
}
