using DevLearningAPI.Models.Dtos.CareerItem;
using Microsoft.AspNetCore.Mvc;

namespace DevLearningAPI.Controllers.Interfaces
{
    public interface ICareerItemController
    {
        Task<ActionResult> CreateCareeritemAsync(CreateCareerItemDto careerItem);

        Task<ActionResult> UpdateCareerItemAsync(UpdateCareerItemDto careerItem);

        Task<ActionResult> DeleteAllCareerItemByCareerIdAsync(Guid careerId);

        Task<ActionResult> DeleteAllCareerItemByCourseIdAsync(Guid courseId);

        Task<ActionResult> DeleteCareerItemByCareerCourseIdAsync(Guid careerId, Guid courseId);

    }
}
