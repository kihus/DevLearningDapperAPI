using DevLearningAPI.Models;
using DevLearningAPI.Models.Dtos.Career;
using DevLearningAPI.Repositories.Interfaces;
using DevLearningAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevLearningAPI.Services
{
    public class CareerService : ICareerService
    {

        #region RepositoryDependencyInjection
        private readonly ICareerRepository _careerRepository;

        public CareerService(ICareerRepository careerRepository)
        {
            this._careerRepository = careerRepository;
        }
        #endregion

        public async Task CreateCareerAsync(CreateCareerDto career)
        {
            var newCareer = new Career
            (
                career.Title,
                career.Summary,
                career.Url,
                career.DurationInMinutes,
                career.Featured,
                career.Tags
            );
            await _careerRepository.CreateCareerAsync(newCareer);
        }

        public async Task<List<CareerResponseDto>> GetAllCareersAsync()
        {
            var careers = await _careerRepository.GetAllCareersAsync();
            return careers.OrderBy(x => x.Title).ToList();
        }

        public async Task<CareerResponseDto> GetCareerByIdAsync(Guid careerId)
        {
            return await _careerRepository.GetCareerByIdAsync(careerId);
        }

        public async Task UpdateCareerAsync(Guid careerId, UpdateCareerDto careerRequest)
        {
            var career = await _careerRepository.GetCareerByIdAsync(careerId);
            var newCareer = new Career(
                string.IsNullOrEmpty(careerRequest.Title)
                                        ? career.Title
                                        : careerRequest.Title,
                string.IsNullOrEmpty(careerRequest.Summary)
                                        ? career.Summary
                                        : careerRequest.Summary,
                string.IsNullOrEmpty(careerRequest.Url)
                                        ? career.Url
                                        : careerRequest.Url,
                careerRequest.DurationInMinutes is 0
                                        ? career.DurationInMinutes
                                        : careerRequest.DurationInMinutes,
                careerRequest.Featured is false
                                        ? career.Featured
                                        : careerRequest.Featured,
                string.IsNullOrEmpty(careerRequest.Tags)
                                        ? career.Tags
                                        : careerRequest.Tags
                );
            await _careerRepository.UpdateCareerAsync(careerId, newCareer);
        }

        public async Task ChangeActiveAsync(Guid careerId)
        {
            await _careerRepository.ChangeActiveAsync(careerId);
        }
    }
}
