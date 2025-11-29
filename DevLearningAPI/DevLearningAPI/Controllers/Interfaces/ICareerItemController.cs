using DevLearningAPI.Models.Dtos.CareerItem;
using Microsoft.AspNetCore.Mvc;

namespace DevLearningAPI.Controllers.Interfaces
{
    public interface ICareerItemController
    {
        Task<ActionResult> CreateCareeritemAsync(CreateCareerItemDto careerItem);
    }
}
