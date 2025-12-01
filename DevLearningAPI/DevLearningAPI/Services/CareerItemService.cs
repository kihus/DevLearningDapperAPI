using DevLearningAPI.Models;
using DevLearningAPI.Models.Dtos.CareerItem;
using DevLearningAPI.Repositories.Interfaces;
using DevLearningAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevLearningAPI.Services
{
    public class CareerItemService : ICareerItemService
    {

        #region RepositoryDependecyInjection
        private readonly ICareerItemRepository _careerItemRepository;

        public CareerItemService(ICareerItemRepository careerItemRepository)
        {
            _careerItemRepository = careerItemRepository;
        }
        #endregion

        public async Task CreateCareeritemAsync(CreateCareerItemDto careerItem)
        {
            var newCareerItem = new CareerItem(
                                                careerItem.CareerId,
                                                careerItem.CourseId,
                                                careerItem.Title,
                                                careerItem.Description,
                                                careerItem.Order
                                              );
            await _careerItemRepository.CreateCareerItemAsync(newCareerItem);
        }

        public async Task<CareerItemResponseDto> GetCareerItemByCareerIdAsync(Guid careerId)
        {
            return await _careerItemRepository.GetCareerItemByCareerIdAsync(careerId);
        }

        public async Task<CareerItemResponseDto> GetCareerItemByCourseIdAsync(Guid courseId)
        {
            return await _careerItemRepository.GetCareerItemByCourseIdAsync(courseId);
        }

        public async Task<CareerItemResponseDto> GetCareerItemByCareerCourseIdAsync(Guid careerId, Guid courseId)
        {
            return await _careerItemRepository.GetCareerItemByCareerCourseIdAsync(careerId,courseId);
        }

        public async Task UpdateCareerItemAsync(UpdateCareerItemDto careerItem)
        {
            var newCareerItem = new CareerItem(
                                                careerItem.CareerId,
                                                careerItem.CourseId,
                                                careerItem.Title,
                                                careerItem.Description,
                                                careerItem.Order
                                              );
            await _careerItemRepository.UpdateCareerItemAsync(newCareerItem);
        }

        public async Task DeleteAllCareerItemByCareerIdAsync(Guid careerId)
        {
            await _careerItemRepository.DeleteAllCareerItemByCareerIdAsync(careerId);
        }

        public async Task DeleteAllCareerItemByCourseIdAsync(Guid courseId)
        {
            await _careerItemRepository.DeleteAllCareerItemByCourseIdAsync(courseId);
        }

        public async Task DeleteCareerItemByCareerCourseIdAsync(Guid careerId, Guid courseId)
        {
            await _careerItemRepository.DeleteCareerItemByCareerCourseIdAsync(careerId,courseId);
        }

    }
}
