using DevLearningAPI.Models.Dtos.CareerItem;
using Microsoft.AspNetCore.Mvc;

namespace DevLearningAPI.Services.Interfaces
{
    public interface ICareerItemService
    {
        Task CreateCareeritemAsync(CreateCareerItemDto careerItem);

        Task<CareerItemResponseDto> GetCareerItemByCareerIdAsync(Guid careerId);

        Task<CareerItemResponseDto> GetCareerItemByCourseIdAsync(Guid courseId);

        Task<CareerItemResponseDto> GetCareerItemByCareerCourseIdAsync(Guid careerId, Guid courseId);

        Task UpdateCareerItemAsync(UpdateCareerItemDto careerItem);

        Task DeleteAllCareerItemByCareerIdAsync(Guid careerId);

        Task DeleteAllCareerItemByCourseIdAsync(Guid courseId);

        Task DeleteCareerItemByCareerCourseIdAsync(Guid careerId, Guid courseId);
    }
}
