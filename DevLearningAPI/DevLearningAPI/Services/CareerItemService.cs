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

        public async Task UpdateCareerItemAsync(Guid idCareer, Guid idCourse, UpdateCareerItemDto careerItemRequest)
        {
            var careerItemCareer = await _careerItemRepository.GetCareerItemByCareerIdAsync(idCareer);
            var careerItemCourse = await _careerItemRepository.GetCareerItemByCourseIdAsync(idCourse);
            var careerItem = await _careerItemRepository.GetCareerItemByCareerCourseIdAsync(idCareer, idCourse);

            var newCareerItem = new CareerItem(
                                                careerItemRequest.CareerId,
                                                careerItemRequest.CourseId,
                           string.IsNullOrEmpty(careerItemRequest.Title) 
                                              ? careerItem.Title 
                                              : careerItemRequest.Title,
                           string.IsNullOrEmpty(careerItemRequest.Description) 
                                              ? careerItem.Description 
                                              : careerItemRequest.Description,
                                                careerItemRequest.Order is 0 
                                              ? careerItem.Order 
                                              : careerItemRequest.Order
                                              );
            await _careerItemRepository.UpdateCareerItemAsync(idCareer, idCourse, newCareerItem);
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
