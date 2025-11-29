using DevLearningAPI.Models;
using DevLearningAPI.Models.Dtos.CareerItem;
using DevLearningAPI.Repositories.Interfaces;
using DevLearningAPI.Services.Interfaces;

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
    }
}
