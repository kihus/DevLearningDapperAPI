using DevLearningAPI.Models;

namespace DevLearningAPI.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task CreateCareerItemAsync(CareerItem careerItem);
}
