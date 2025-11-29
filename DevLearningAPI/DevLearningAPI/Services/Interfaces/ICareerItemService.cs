using DevLearningAPI.Models.Dtos.CareerItem;
using Microsoft.AspNetCore.Mvc;

namespace DevLearningAPI.Services.Interfaces
{
    public interface ICareerItemService
    {
        Task CreateCareeritemAsync(CreateCareerItemDto careerItem);
    }
}
