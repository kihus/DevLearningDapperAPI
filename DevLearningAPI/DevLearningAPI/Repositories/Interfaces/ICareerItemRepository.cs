using DevLearningAPI.Models;
using DevLearningAPI.Models.Dtos.CareerItem;

namespace DevLearningAPI.Repositories.Interfaces
{
    public interface ICareerItemRepository
    {
        Task CreateCareerItemAsync(CareerItem careerItem);

        Task<CareerItemResponseDto> GetCareerItemByCareerIdAsync(Guid careerId);

        Task<CareerItemResponseDto> GetCareerItemByCourseIdAsync(Guid courseId);

        Task<CareerItemResponseDto> GetCareerItemByCareerCourseIdAsync(Guid careerId, Guid courseId);

        Task UpdateCareerItemAsync(Guid idCareer, Guid idCourse, CareerItem careerItemRequest);

        Task DeleteAllCareerItemByCareerIdAsync(Guid careerId);

        Task DeleteAllCareerItemByCourseIdAsync(Guid courseId);

        Task DeleteCareerItemByCareerCourseIdAsync(Guid careerId, Guid courseId);
    }
}
