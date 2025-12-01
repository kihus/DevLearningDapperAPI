using DevLearningAPI.Models.Dtos.Career;
using Microsoft.AspNetCore.Mvc;

namespace DevLearningAPI.Controllers.Interfaces
{
    public interface ICareerController
    {
        Task<ActionResult> CreateCareerAsync(CreateCareerDto career);

        Task<ActionResult<List<CareerResponseDto>>> GetAllCareersAsync();

        Task<ActionResult<CareerResponseDto>> GetCareerByIdAsync(Guid careerId);

        Task<ActionResult> UpdateCareerAsync(Guid careerId, UpdateCareerDto careerRequest);

        Task<ActionResult> ChangeActiveAsync(Guid career);
    }
}
