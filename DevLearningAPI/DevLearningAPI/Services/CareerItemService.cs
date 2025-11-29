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

        private readonly ICareerRepository _careerRepository;

        private readonly ICourseRepository _courseRepository;

        public CareerItemService(ICareerItemRepository careerItemRepository,ICareerRepository careerRepository,ICourseRepository courseRepository)
        {
            _careerItemRepository = careerItemRepository;
            _careerRepository = careerRepository;
            _courseRepository = courseRepository;
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
            await _careerItemRepository.CreateCareeritemAsync(newCareerItem);
        }
    }
}
