using DevLearningAPI.Models;

namespace DevLearningAPI.Repositories.Interfaces
{
    public interface ICareerItemRepository
    {
        Task CreateCareerItemAsync(CareerItem careerItem);
    }
}
